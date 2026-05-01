using SeafoodSysteBeta.Enums;

namespace SeafoodSysteBeta.Models
{
    public class SeafoodItem : MenuItem
    {
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}