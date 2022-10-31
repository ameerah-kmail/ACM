using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    internal class OrderRepository
    {
        public Order Retrieve(int OrderId)
        {
            Order order = new Order(OrderId);
            if (OrderId == 1)
            {
                order.ShippingAddress = "mm mm";
                order.OrderDate = DateTime.Now;
            }
            return order;
        }
        public bool save(Order order)
        {
            var success = true;
            if (order.IsValid)
            {
                if (order.IsNew)
                {
                    //////////////////
                }
                else
                {
                    /////////////////////////
                }
            }
            else
            {
                success = false;
            }
            return success;
        }
    }
}
