using System;
using System.Collections.Generic;
using System.Text;

namespace SeafoodSysteBeta.Managers
{
    public class PromoManager
    {
        public double GetDiscount(string code, double subtotal)
        {
            if (code == "SALE10")
                return subtotal * 0.1;

            if (code == "SALE20")
                return subtotal * 0.2;
            if (code == "SALE30")
                return subtotal * 0.3;

            return 0;
        }
    }
}
