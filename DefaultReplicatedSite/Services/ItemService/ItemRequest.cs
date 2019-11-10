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
        public IOrderConfiguration Configuration { get; set; }
        public List<int> ItemIds { get; set; }
        public int WebCaegoryID { get; set; }
    }
}