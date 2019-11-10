using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Common;
using DefaultReplicatedSite.Services;
using MakoLibrary.Contracts;
using Newtonsoft.Json;

namespace DefaultReplicatedSite
{

    public class OwnerIdentity : IIdentity
    {

        public OwnerIdentity()
        {
        }

        #region IIdentity Settings
        string IIdentity.AuthenticationType
        {
            get { return "Custom"; }
        }
        bool IIdentity.IsAuthenticated
        {
            get { return true; }
        }
        public string Name { get; set; }
        #endregion

        #region Properties
        public string Gender { get; set; }
        public string CustomerId { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerTypeDescription { get; set; }
        public int CustomerStatusId { get; set; }
        public string CustomerStatusDescription { get; set; }
        public int HighestAchievedRankID { get; set; }
        public DateTime CreatedDate { get; set; }

        public string WebAlias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int RankId { get; set; }
        public string RankDescription { get; set; }

        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
        //public Market Market
        //{
        //    get { return Utilities.GetCurrentMarket(); }
        //}
        public bool IsOrphan
        {
            get
            {
                return Settings.Site.DefaultWebalias.Equals(this.WebAlias, StringComparison.InvariantCultureIgnoreCase);
            }
        }
        #endregion
    }
}