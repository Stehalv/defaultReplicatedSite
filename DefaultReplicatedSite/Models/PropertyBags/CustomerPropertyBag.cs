using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class CustomerPropertyBag : BasePropertyBag
    {
        public CustomerPropertyBag()
        {
            Customer = new Customer();
        }
        public Customer Customer { get; set; }
    }
}