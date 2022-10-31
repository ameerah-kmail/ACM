using Acme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    internal class Product:EntityBase,ILoggable
    {
        public int ProductId { get;private set; }
        private string _productName;
        public string ProductName {
            get {
                //return StringHandler.InsertSpaces(_productName);
                return _productName.InsertSpaces();//extension method for string
            }

            set { _productName = value; }
        }
        public string Descrition { get; set; }
        public decimal? CurrentPrice { get; set; }
        public Product()
        {

        }
        public Product(int productId)
        {
            ProductId = productId;
        }
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName))
                isValid = false;
            if(CurrentPrice == null)    
                isValid = false;
            return isValid;

        }
        public override string ToString() => ProductName;
        public string Log() =>
        $"{ProductId}: {ProductName} Descrition: {Descrition} Status: {EntityState.ToString()}";


    }
}
