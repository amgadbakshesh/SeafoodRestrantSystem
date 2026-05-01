using SeafoodSysteBeta.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeafoodSysteBeta.Managers
{
    public class OrderManager
    {
        private OrderItem[] orders = new OrderItem[100];
        private int count = 0;

        public void AddOrder(OrderItem order)
        {
            orders[count++] = order;
        }

        public OrderItem[] GetOrders()
        {
            return orders;
        }

        public int Count => count;

        public double GetSubtotal()
        {
            double total = 0;
            for (int i = 0; i < count; i++)
            {
                total += orders[i].GetTotal();
            }
            return total;
        }

        public void Clear()
        {
            orders = new OrderItem[100];
            count = 0;
        }
    }
}
