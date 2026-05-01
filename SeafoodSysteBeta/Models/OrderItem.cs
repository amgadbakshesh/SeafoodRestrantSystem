using System;
using System.Collections.Generic;
using System.Text;

namespace SeafoodSysteBeta.Models
{
    public class OrderItem
    {
        public SeafoodItem Item { get; set; }
        public int Quantity { get; set; }

        public double GetTotal()
        {
            return Item.Price * Quantity;
        }
    }
}
