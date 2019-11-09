using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite
{
    public class UnitedStatesConfigurations : IMarketConfiguration
    {
        public IOrderConfiguration Order
        {
            get
            {
                return new OrderConfiguration();
            }
        }
        public IOrderConfiguration AutoOrder
        {
            get
            {
                return new AutoOrderConfiguration();
            }
        }
        public IOrderConfiguration Enrollment
        {
            get
            {
                return new OrderConfiguration();
            }
        }
        public IOrderConfiguration EnrollmentAutoOrder
        {
            get
            {
                return new OrderConfiguration();
            }
        }
        public class BaseOrderConfiguration : IOrderConfiguration
        {
            public BaseOrderConfiguration()
            {
                PriceTypeID = 1;
                CountryCode = "US";
            }

            public int PriceTypeID { get; set; }
            public string CountryCode { get; set; }
        }
        public class OrderConfiguration : BaseOrderConfiguration
        {
            public OrderConfiguration()
            {

            }
        }
        public class AutoOrderConfiguration : BaseOrderConfiguration
        {
            public AutoOrderConfiguration()
            {
                PriceTypeID = 2;
            }
        }
        public class EnrollmentConfiguration : BaseOrderConfiguration
        {
            public EnrollmentConfiguration()
            {
                PriceTypeID = 2;
            }
        }
        public class EnrollmentAutoOrderConfiguration : BaseOrderConfiguration
        {
            public EnrollmentAutoOrderConfiguration()
            {
                PriceTypeID = 2;
            }
        }
    }
}