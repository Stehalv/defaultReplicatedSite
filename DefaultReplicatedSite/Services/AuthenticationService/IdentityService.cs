using System;
using System.Web;
using System.Web.Security;

namespace DefaultReplicatedSite.Services
{
    public class IdentityService
    {
        public bool SignIn(string username, string password)
        {
            try
            {
                // authenticate user - through client credentials
                // var customerResponse = Teqnavi.ServiceContext().GetCrmCustomerByUsernameAndPassword(username, password);

                //if (customerResponse.Success)
                //{
                var identity = GetIdentity("5");

                if (identity == null)
                {
                    return false;
                }

                return CreateFormsAuthenticationTicket(identity);
                // }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public void SignOut()
        {
            if (HttpContext.Current.Request.Cookies["MakoBackOfficeToken"] != null)
            {
                HttpCookie myCookie = new HttpCookie("MakoBackOfficeToken")
                {
                    Expires = DateTime.Now.AddDays(-1d)
                };

                HttpContext.Current.Response.Cookies.Add(myCookie);
            }

            FormsAuthentication.SignOut();
        }

        public bool CreateFormsAuthenticationTicket(string CustomerId)
        {
            var identity = GetIdentity(CustomerId);

            if (identity == null)
            {
                return false;
            }

            return CreateFormsAuthenticationTicket(identity);
        }
        public bool CreateFormsAuthenticationTicket(UserIdentity identity)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                identity.User.CustomerId.ToString(),
                DateTime.Now,
                DateTime.Now.AddMinutes(Settings.API.SessionTimeout),
                false,
                identity.SerializeProperties());

            // Encrypt the ticket
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
                {
                    HttpOnly = true
                };

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = encTicket;
                HttpContext.Current.Response.Cookies.Set(cookie);
            }

            // Add the customer ID to the items in case we need this in the same request later on.
            // We need this because we don't have access to the Identity.Current in this same request later on.
            HttpContext.Current.Items.Add("CustomerID", identity.User.CustomerId);

            return true;
        }

        public UserIdentity GetIdentity(string customerID)
        {
            dynamic identity = null;

            try
            {
                var customer = Teqnavi.ServiceContext().GetCustomer(customerID);

                if (customer != null && customer.Data != null)
                {
                    identity = new UserIdentity()
                    {
                        User = new UserIdentity.TicketProperties()
                        {
                            AppVersion = Settings.API.Version,
                            CustomerId = customer.Data.CustomerIdExternal,
                            FirstName = customer.Data.FirstName,
                            LastName = customer.Data.LastName,
                            Gender = customer.Data.Gender,
                            CustomerTypeId = customer.Data.CustomerType,
                            CustomerTypeDescription = customer.Data.CustomerTypeDescription,
                            CustomerStatusId = customer.Data.CustomerStatusType,
                            CustomerStatusDescription = customer.Data.CustomerStatusTypeDescription,
                            Country = customer.Data.CountryCode,
                            RankId = customer.Data.RankId,
                            RankDescription = customer.Data.RankIdDescription
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return identity;
        }

        public OwnerIdentity GetOwnerIdentity(string webAlias)
        {
            webAlias = webAlias.ToUpper();
            var cacheKey = string.Format("{0}-OwnerIdentity-{1}", Settings.Company.Name, webAlias);
            var identity = HttpContext.Current.Cache[cacheKey] as OwnerIdentity;

            if (identity == null)
            {
                try
                {
                    var customer = Teqnavi.ServiceContext().GetCustomer(webAlias);
                    identity = new OwnerIdentity()
                    {
                        CustomerId = customer.Data.CustomerIdExternal,
                        WebAlias = customer.Data.CustomerIdExternal,
                        FirstName = customer.Data.FirstName,
                        LastName = customer.Data.LastName,
                        Gender = customer.Data.Gender,
                        CustomerTypeId = customer.Data.CustomerType,
                        CustomerTypeDescription = customer.Data.CustomerTypeDescription,
                        CustomerStatusId = customer.Data.CustomerStatusType,
                        CustomerStatusDescription = customer.Data.CustomerStatusTypeDescription,
                        Country = customer.Data.CountryCode,
                        RankId = customer.Data.RankId,
                        RankDescription = customer.Data.RankIdDescription
                    };
                    // Save the identity
                    HttpContext.Current.Cache.Insert(cacheKey,
                        identity,
                        null,
                        DateTime.Now.AddMinutes(Settings.Site.IdentityRefreshInterval),
                        System.Web.Caching.Cache.NoSlidingExpiration,
                        System.Web.Caching.CacheItemPriority.Normal,
                        null);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Default user missing"))
                    {
                        throw ex;
                    }
                    return null;
                }
            }

            return identity;
        }
    }
}