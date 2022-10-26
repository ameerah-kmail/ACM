using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    internal class Product
    {
        public int ProductId { get;private set; }
        public string ProductName { get; set; }
        public string Descrition { get; set; }
        public decimal? CurrentPrice { get; set; }
        public Product()
        {

        }
        public Product(int productId)
        {
            ProductId = productId;
        }
        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName))
                isValid = false;
            if(CurrentPrice == null)    
                isValid = false;
            return isValid;

        }

      
    }
}
