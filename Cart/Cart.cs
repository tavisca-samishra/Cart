using System;
using System.Collections.Generic;

namespace Cart
{
    public class Cart
    {
        private CartItem _cartItem;
        private IDiscount _discount;
        private CategoryDiscount _categoryDiscount;
        public Cart(CartItem cartItem, IDiscount discount)
        {
            _cartItem = cartItem;
            _discount = discount;
        }

        public Cart(CartItem cartItem, CategoryDiscount categoryDiscount)
        {
            _cartItem = cartItem;
            _categoryDiscount = categoryDiscount;
        }

        public double GetTotal()
        {
            double totalPrice = 0;

            if (_categoryDiscount != null)
            {
                Dictionary<Category, int> categoryDiscountList = _categoryDiscount.GetCategoryDiscount();
                foreach (var item in _cartItem.GetItems())
                {
                    totalPrice += item.Value * (item.Key.Price - (item.Key.Price * categoryDiscountList[item.Key.Category]) / 100);
                }
            }
            else
            {
                foreach (var item in _cartItem.GetItems())
                {
                    totalPrice += item.Value * item.Key.Price;
                }
                totalPrice = totalPrice - (totalPrice * _discount.GetDiscount()) / 100;
            }


            return totalPrice;
        }

    }
}
