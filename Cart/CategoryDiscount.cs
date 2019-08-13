using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    public class CategoryDiscount 
    {
        private Dictionary<Category, int> _categoryDiscountList = new Dictionary<Category, int>();

        public void AddCategoryDiscount(Category category ,int discountPercent)
        {
            _categoryDiscountList.Add(category, discountPercent);
        }

        public Dictionary<Category, int> GetCategoryDiscount()
        {
            return _categoryDiscountList;
        }

    }
}
