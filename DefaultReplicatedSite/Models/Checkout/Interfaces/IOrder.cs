using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite.Models
{
    public interface IOrder
    {
        int OrderID { get; set; }
        List<Item> Items { get; set; }
        int ShipMethodID { get; set; }
        decimal SubTotal { get; }
        decimal Shipping { get; set; }
        decimal Tax { get; set; }
        decimal Total { get; }
    }
}
