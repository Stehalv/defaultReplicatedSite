using Common;
using DefaultReplicatedSite.Services;
using MakoLibrary.Contracts;
using Newtonsoft.Json;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace DefaultReplicatedSite
{
    public static class Identity
    {
        public static UserIdentity Customer
        {
            get
            {
                try
                {
                    return HttpContext.Current.User.Identity as UserIdentity;
                }
                catch
                {
                    return null;
                }
            }
        }
        //public static OwnerIdentity Owner
        //{
        //    get
        //    {
        //        var identity = (HttpContext.Current.Items["OwnerWebIdentity"] as OwnerIdentity);

        //        if (identity == null)
        //        {

        //            var identityService = new IdentityService();
        //            identity = identityService.GetOwnerIdentity(Settings.Site.DefaultWebalias);
        //            HttpContext.Current.Items["OwnerWebIdentity"] = identity;
        //        }

        //        return identity;
        //    }
        //}
    }

    public class UserIdentity : IIdentity
    {
        public UserIdentity()
        {
            User = new TicketProperties();
        }
        public UserIdentity(FormsAuthenticationTicket ticket)
        {
            Name = ticket.Name;
            Expiration = ticket.Expiration;

            DeserializeProperties(ticket.UserData);
        }

        public void Renew()
        {
            var service = new IdentityService();
            service.CreateFormsAuthenticationTicket(User.CustomerId);
        }

        public string Name { get; set; }
        public DateTime Expiration { get; set; }

        string IIdentity.AuthenticationType
        {
            get { return "Custom"; }
        }

        bool IIdentity.IsAuthenticated
        {
            get { return true; }
        }

        #region Cached Retrievables - From Functions
        private PeriodContract _currentPeriod { get; set; }
        public PeriodContract CurrentDefaultPeriod
        {
            get
            {
                if (_currentPeriod != null) return _currentPeriod;

                _currentPeriod = new GlobalUtilities.Mako().GetCurrentPeriod(PeriodType.Default);

                return _currentPeriod;
            }
        }

        private PeriodContract _currentSecondaryPeriod { get; set; }
        public PeriodContract CurrentSecondaryPeriod
        {
            get
            {
                if (_currentSecondaryPeriod != null) return _currentSecondaryPeriod;

                _currentSecondaryPeriod = new GlobalUtilities.Mako().GetCurrentPeriod(PeriodType.Secondary);

                return _currentSecondaryPeriod;
            }
        }
        #endregion

        #region Serialization
        public string SerializeProperties()
        {
            return JsonConvert.SerializeObject(User);
        }
        public void DeserializeProperties(string data)
        {
            User = JsonConvert.DeserializeObject<TicketProperties>(data);
        }
        public static UserIdentity Deserialize(string data)
        {
            try
            {
                var ticket = FormsAuthentication.Decrypt(data);
                return new UserIdentity(ticket);
            }
            catch
            {
                new IdentityService().SignOut();
                return null;
            }
        }
        #endregion

        #region Properties
        public TicketProperties User { get; set; }

        public class TicketProperties
        {
            public string AppVersion { get; set; }
            public string CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string Country { get; set; }
            public int CustomerTypeId { get; set; }
            public string CustomerTypeDescription { get; set; }
            public int CustomerStatusId { get; set; }
            public string CustomerStatusDescription { get; set; }
            public int RankId { get; set; }
            public string RankDescription { get; set; }
        }
        #endregion
    }
}