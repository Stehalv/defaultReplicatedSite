using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite.Models
{
    public interface IShoppingCartItem
    {
        Guid ID { get; set; }
        int ItemId { get; set; }
        string ItemCode { get; set; }
        decimal Quantity { get; set; }
        int OrderLineNumber { get; set; }
    }
}
