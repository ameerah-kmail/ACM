using Acme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class Order: EntityBase,ILoggable
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
        public override bool Validate()
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
        public override string ToString()
        {
            return $"{OrderDate.Value.Date}({OrderId})";
        }

        public string Log() =>
       $"{OrderId}: Date: {this.OrderDate.Value.Date} Status: {EntityState.ToString()}";
    }
}
