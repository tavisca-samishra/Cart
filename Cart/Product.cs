using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; }

        public Product(string name, int price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
