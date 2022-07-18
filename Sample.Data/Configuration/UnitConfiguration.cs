using Sample.Model;
using System.Data.Entity.ModelConfiguration;

namespace Sample.Data
{
    public class UnitConfiguration : EntityTypeConfiguration<Unit>
    {
        public UnitConfiguration()
        {
            ToTable(TableName.Units);
            HasKey(u => u.UnitId);
            Property(p => p.UnitName).IsRequired().HasMaxLength(200);

            HasMany(u => u.Products)
            .WithRequired(u => u.Unit)
            .HasForeignKey(u => u.UnitId);
            
        }
    }
}
