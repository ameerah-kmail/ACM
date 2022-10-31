using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    internal class ProductRepository
    {
        public bool Save(Product product)
        {
            var success = true;
            if (product.IsValid)
            {
                if (product.IsNew)
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
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);
            if (productId == 1)
            {
                product.CurrentPrice = 110;
                product.ProductName = "XXX";
                product.Descrition = "------------";
            }
            return new Product();
        }
    }
}
