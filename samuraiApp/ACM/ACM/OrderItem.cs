using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class OrderItem: EntityBase
    {
        public OrderItem()
        {

        }
        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }
        public int OrderItemId { get;private set; }  
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public override bool Validate()
        {
            var isValid = true;
            if(Quantity <=0) isValid = false;
            if(ProductId <=0) isValid = false;
            if (PurchasePrice <= null) isValid = false;
            return isValid;

        }
        public bool Save()
        {
            return true;
        }
        public OrderItem Retrieve(int customerId)
        {
            return new OrderItem();
        }
        public List<OrderItem> Retrieve()
        {
            return new List<OrderItem>();
        }
    }
}
