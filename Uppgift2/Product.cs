using System;
namespace Uppgift2
{
    public class Product
    {
        public String productName { get; set; }
        public int price { get; set; }


        public Product(String productName, int price)
        {
            this.productName = productName;
            this.price = price;
        }
    }
}

