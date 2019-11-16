using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class ItemRequest
    {
        public ItemRequest()
        {

        }
        public ItemRequest(IOrderConfiguration config, List<int> itemIds = null)
        {
            Configuration = config;
            ItemIds = itemIds;
        }
        public ItemRequest(IOrderConfiguration config, bool SingleRequest = false, string itemId = "")
        {
            Configuration = config;
            SingleItemRequest = SingleRequest;
            ItemId = itemId;
        }
        public IOrderConfiguration Configuration { get; set; }
        public List<int> ItemIds { get; set; }
        public int WebCaegoryID { get; set; }
        public bool SingleItemRequest { get; set; }
        public string ItemId { get; set; }
    }
}