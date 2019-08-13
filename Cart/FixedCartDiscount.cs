using System;
using System.Collections.Generic;
using System.Text;

namespace Cart
{
    public class FixedCartDiscount:IDiscount
    {
        public int GetDiscount()
        {
            return 10;
        }
    }
}
