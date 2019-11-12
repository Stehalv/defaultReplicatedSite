using MakoLibrary.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace DefaultReplicatedSite
{
    public partial class GlobalUtilities
    {
        public class Mako
        {
            public PeriodContract GetCurrentPeriod(int periodTypeId)
            {
                var response = Teqnavi.ServiceContext().GetPeriods();

                if (!response.Success || response.Data == null) return null;

                // get current period using start and end(+24hours) dates
                var currentPeriod = response.Data
                    .Where(w => w.PeriodTypeId == periodTypeId)
                    .Where(w => w.StartDate <= DateTime.Now && w.EndDate.AddDays(1) >= DateTime.Now)
                    .FirstOrDefault();

                // in case no period for this period, get max of current periods available
                if (currentPeriod == null)
                {
                    currentPeriod = response.Data.Where(w => w.PeriodTypeId == periodTypeId && w.PeriodId == response.Data.Max(m => m.PeriodId)).FirstOrDefault();
                }

                return currentPeriod ?? new PeriodContract();
            }

        }
        public static class Globalization
        {
            public static Market GetSelectedMaret()
            {
                var countryCode = GetSelectedCountryCode();
                return Settings.Globalization.Markets.AvailableMarkets.FirstOrDefault(c => c.CountryCode == countryCode);
            }
            public static string GetSelectedLanguage()
            {
                var defaultLanguage = Settings.Globalization.Markets.AvailableMarkets.Where(c => c.IsDefault).FirstOrDefault().CultureCode;
                var languageCookie = HttpContext.Current.Request.Cookies[Settings.Globalization.LanguageCookieName];

                if (languageCookie == null)
                {
                    languageCookie = new HttpCookie(Settings.Globalization.LanguageCookieName);
                    languageCookie.Value = defaultLanguage;
                    languageCookie.HttpOnly = false;
                    HttpContext.Current.Response.Cookies.Add(languageCookie);
                } languageCookie.Value = defaultLanguage;


                return languageCookie.Value;
            }
            public static void SetCurrentCulture(string cultureCode)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureCode);
            }

            public static void SetCurrentUICulture(string cultureCode)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureCode);
            }

            public static string GetSelectedCountryCode(string countryCode = "US")
            {
                var cookie = HttpContext.Current.Request.Cookies[Settings.Globalization.CountryCookieName];

                if (countryCode != "US")
                {
                    cookie = new HttpCookie(Settings.Globalization.CountryCookieName);
                    cookie.Value = countryCode;
                    cookie.HttpOnly = false;
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return countryCode;
                }

                if (cookie != null && !cookie.Value.IsEmpty())
                {
                    return cookie.Value;
                }
                else
                {
                    cookie = new HttpCookie(Settings.Globalization.CountryCookieName);
                    cookie.Value = countryCode;
                    cookie.HttpOnly = false;
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return cookie.Value;
                }
            }

            public static string SetSelectedCountryCode(string countryCode)
            {
                var cookie = HttpContext.Current.Request.Cookies[Settings.Globalization.CountryCookieName];

                if (cookie != null && !cookie.Value.IsEmpty())
                {
                    cookie.HttpOnly = false;
                    cookie.Value = countryCode;
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return cookie.Value;
                }
                else
                {
                    cookie = new HttpCookie(Settings.Globalization.CountryCookieName);
                    cookie.Value = countryCode;
                    cookie.HttpOnly = false;
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return cookie.Value;
                }
            }
        }
    }
}