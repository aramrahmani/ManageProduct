
namespace Sample.Web.ViewModels
{
    public class ProductViewModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Count { get; set; }

        public long UnitId { get; set; }
        public virtual UnitViewModel Unit { get; set; }
    }

    public class ProductsDataTableViewModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Count { get; set; }
        public long UnitId { get; set; }
        public string UnitTitle { get; set; }
    }
}