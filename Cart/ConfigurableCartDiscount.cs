using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    public class ConfigurableCartDiscount:IDiscount
    {
        private int _discountPercent;

        public ConfigurableCartDiscount(int discountPercent)
        {
            _discountPercent = discountPercent;
        }
        public int GetDiscount()
        {
            return _discountPercent;
        }
    }
}
