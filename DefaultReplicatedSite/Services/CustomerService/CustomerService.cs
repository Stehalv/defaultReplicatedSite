using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryCommon;

namespace DefaultReplicatedSite.Services
{
    public class CustomerService
    {
        public Customer GetCustomer(long customerID)
        {
            return new Customer();
        }
        #region Validations
        public bool IsUserNameAvailable(string userName)
        {
            var filter = new MakoFilterQueryContract
            {
                SearchList = new List<MakoFilterSearchData>
                {
                    new MakoFilterSearchData
                    {
                        SearchFilter    = nameof(CRMCustomerContract.UserName),
                        SearchMethod    = ApiQuery.SearchMethod.IsEqual,
                        SearchValue     = userName
                    }
                }
            };
            var response = Teqnavi.ServiceContext().GetCrmCustomers(filter);
            if (response.Data.Count() > 0)
                return false;
            else
                return true;
        }
        public bool IsTaxIDAvailable(string taxId)
        {
            var filter = new MakoFilterQueryContract
            {
                SearchList = new List<MakoFilterSearchData>
                {
                    new MakoFilterSearchData
                    {
                        SearchFilter    = nameof(CRMCustomerContract.TaxId),
                        SearchMethod    = ApiQuery.SearchMethod.IsEqual,
                        SearchValue     = taxId
                    }
                }
            };
            var response = Teqnavi.ServiceContext().GetCrmCustomers(filter);
            if (response.Data.Count() > 0)
                return false;
            else
                return true;
        }
        public bool IsWebAliasAvailable(string webAlias)
        {
            var filter = new MakoFilterQueryContract
            {
                SearchList = new List<MakoFilterSearchData>
                {
                    new MakoFilterSearchData
                    {
                        SearchFilter    = nameof(CRMCustomerContract.WebAlias),
                        SearchMethod    = ApiQuery.SearchMethod.IsEqual,
                        SearchValue     = webAlias
                    }
                }
            };
            var response = Teqnavi.ServiceContext().GetCrmCustomers(filter);
            if (response.Data.Count() > 0)
                return false;
            else
                return true;
        }
        #endregion
    }
}