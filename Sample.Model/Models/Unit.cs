

using System.Collections.Generic;

namespace Sample.Model
{
    public class Unit
    {
        public long UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
