using Sample.Model;
using System.Data.Entity.ModelConfiguration;

namespace Sample.Data
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable(TableName.Products);
            HasKey(p => p.ProductId);
            Property(p => p.ProductName).IsRequired().HasMaxLength(200);
            Property(p => p.Count).IsRequired();
            Property(p => p.UnitId).IsRequired();
            
        }
    }
}
