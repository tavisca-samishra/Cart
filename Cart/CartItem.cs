using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    public class CartItem
    {
        private Dictionary<Product, int> _cartItems = new Dictionary<Product, int>();
        public Dictionary<Product, int> ItemList()
        {
            return _cartItems;
        }
        public void AddItem(Product product,int quantity)
        {
            if (quantity < 1)
                throw new NotSupportedException();
            else
                _cartItems[product] = quantity;
        }
        public Dictionary<Product,int> GetItems()
        {
            return _cartItems;
        }

    }
}
