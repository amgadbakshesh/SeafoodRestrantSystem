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

        //order add one by one
        public void AddOrder(OrderItem order)
        {
            orders[count++] = order;
        }
        //return all order
        public OrderItem[] GetOrders()
        {
            return orders;
        }

        public int Count
        { get { return count; } }
        //Subtotal
        public double GetSubtotal()
        {
            double total = 0;
            for (int i = 0; i < count; i++)
            {
                total += orders[i].GetTotal();
            }
            return total;
        }
        //tax
        public double GetTax(double subtotal)
        {
            return subtotal * 0.14;
        } 
        //clear 
        public void Clear()
        {
            orders = new OrderItem[100];
            count = 0;
        }
    }
}
