

using System;

namespace Sample.Model
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Count { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public long UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public Product()
        {
            DateCreated = DateTime.Now;
        }
    }

}