using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DefaultReplicatedSite.Helpers
{
    public static class FormHtmlHelpers
    {
        public static IEnumerable<SelectListItem> BirthYears(this HtmlHelper helper, int maxYearOffset = 18, int yearCount = 100, int defaultYear = 0)
        {
            var years = new List<SelectListItem>();
            var startDate = DateTime.Now.AddYears(-maxYearOffset);
            var endDate = startDate.AddYears(-yearCount);
            defaultYear = (defaultYear == 0) ? DateTime.Now.Year : defaultYear;

            for (var year = startDate.Year; year >= endDate.Year; year--)
            {
                years.Add(new SelectListItem()
                {
                    Text = year.ToString(),
                    Value = year.ToString(),
                    Selected = (year == defaultYear)
                });
            }

            return years.AsEnumerable();
        }
        public static IEnumerable<SelectListItem> Days(this HtmlHelper helper, int days = 31, int defaultDay = 0)
        {
            for (int i = 1; i <= days; i++)
            {
                yield return new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = i == defaultDay
                };
            }
        }
        public static IEnumerable<SelectListItem> Months(this HtmlHelper helper, int defaultMonth = 0)
        {
            return DateTimeFormatInfo
                       .CurrentInfo
                       .MonthNames
                       .Where(m => !string.IsNullOrEmpty(m))
                       .Select((monthName, index) => new SelectListItem
                       {
                           Value = (index + 1).ToString(),
                           Text = ((index + 1) + " - " + monthName).ToString(),
                           Selected = (index + 1) == defaultMonth
                       });
        }
        public static IEnumerable<SelectListItem> Years(this HtmlHelper helper, int startYear, int years = 100)
        {
            for (int i = 0; i <= years; i++)
            {
                yield return new SelectListItem()
                {
                    Text = (startYear - i).ToString(),
                    Value = (startYear - i).ToString()
                };
            }
        }

        public static IEnumerable<SelectListItem> ExpirationYears(this HtmlHelper helper, int yearCount = 20)
        {
            var years = new List<SelectListItem>();

            for (var year = DateTime.Now.Year; year <= DateTime.Now.AddYears(yearCount).Year; year++)
            {
                years.Add(new SelectListItem()
                {
                    Text = year.ToString(),
                    Value = year.ToString(),
                    Selected = (year == DateTime.Now.Year)
                });
            }

            return years.AsEnumerable();
        }
    }
}