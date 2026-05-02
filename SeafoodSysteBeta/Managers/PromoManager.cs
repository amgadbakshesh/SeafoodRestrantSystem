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
            if (code == "SAVE100")
                if (subtotal < 150)
                {
                  MessageBox.Show("cart must be at least 150 to apply promo code");
                  return 0;
                }
                else
                    return 100;
                   

            return 0;
        }
    }
}
