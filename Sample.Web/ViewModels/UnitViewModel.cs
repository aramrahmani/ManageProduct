
using System.Collections.Generic;

namespace Sample.Web.ViewModels
{
    public class UnitViewModel
    {
        public long UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}