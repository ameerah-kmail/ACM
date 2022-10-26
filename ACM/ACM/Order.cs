using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class Order
    {
        public int OrderId { get; private set; }
        //Customer _customer;
        public DateTimeOffset? OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Order():this(0)
        {

        }
        public Order(int orderId)
        {
            OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }
        public bool Validate()
        {
            var isValid = true;
            if (OrderDate==null)
                isValid = false;
            return isValid;

        }
        public bool Save()
        {
            return true;
        }
        public Order Retrieve(int customerId)
        {
            return new Order();
        }
        public List<Order> Retrieve()
        {
            return new List<Order>();
        }
    }
}
