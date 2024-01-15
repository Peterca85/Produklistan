using System;


namespace Uppgift2
{
    public class Category
    {
        public String categoryName { get; set; }
        public List<Product> productList { get; set; }


        public Category(string categoryName)
        {

            this.categoryName = categoryName;
            this.productList = new List<Product>();
        }


    }
}

