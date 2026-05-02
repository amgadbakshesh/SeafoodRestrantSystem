using SeafoodSysteBeta.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeafoodSysteBeta.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
     public class seafoodItem : MenuItem 
     {
            public Category Category { get; set; }
     }

    
}