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

    //public class OwnerIdentity : IIdentity
    //{

    //    //public OwnerIdentity()
    //    //{
    //    //}

    //    //#region IIdentity Settings
    //    //string IIdentity.AuthenticationType
    //    //{
    //    //    get { return "Custom"; }
    //    //}
    //    //bool IIdentity.IsAuthenticated
    //    //{
    //    //    get { return true; }
    //    //}
    //    //public string Name { get; set; }
    //    //#endregion

    //    //#region Properties
    //    //public int CustomerID { get; set; }
    //    //public int CustomerTypeID { get; set; }
    //    //public int CustomerStatusID { get; set; }
    //    //public int WarehouseID { get; set; }
    //    //public int HighestAchievedRankID { get; set; }
    //    //public DateTime CreatedDate { get; set; }

    //    //public string WebAlias { get; set; }
    //    //public string FirstName { get; set; }
    //    //public string LastName { get; set; }
    //    //public string Company { get; set; }
    //    //public string Phone { get; set; }
    //    //public string Phone2 { get; set; }
    //    //public string Fax { get; set; }
    //    //public string Email { get; set; }

    //    //public string FacebookUrl { get; set; }
    //    //public string GooglePlusUrl { get; set; }
    //    //public string TwitterUrl { get; set; }
    //    //public string BlogUrl { get; set; }
    //    //public string LinkedInUrl { get; set; }
    //    //public string MySpaceUrl { get; set; }
    //    //public string YouTubeUrl { get; set; }
    //    //public string PinterestUrl { get; set; }
    //    //public string InstagramUrl { get; set; }

    //    //public string Address1 { get; set; }
    //    //public string Address2 { get; set; }
    //    //public string City { get; set; }
    //    //public string State { get; set; }
    //    //public string Zip { get; set; }
    //    //public string Country { get; set; }

    //    //public string Notes1 { get; set; }
    //    //public string Notes2 { get; set; }
    //    //public string Notes3 { get; set; }
    //    //public string Notes4 { get; set; }

    //    //public string FullName
    //    //{
    //    //    get { return this.FirstName + " " + this.LastName; }
    //    //}
    //    //public string DisplayName
    //    //{
    //    //    get { return GlobalUtilities.Coalesce(this.Company, this.FirstName + " " + this.LastName); }
    //    //}
    //    //public Market Market
    //    //{
    //    //    get { return Utilities.GetCurrentMarket(); }
    //    //}
    //    //public bool IsOrphan
    //    //{
    //    //    get
    //    //    {
    //    //        return Settings.Site.DefaultWebalias.Equals(this.WebAlias, StringComparison.InvariantCultureIgnoreCase);
    //    //    }
    //    //}
    //    //#endregion
    //}
}