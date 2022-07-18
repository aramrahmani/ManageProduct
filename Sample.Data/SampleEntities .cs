using Sample.Model;
using System.Data.Entity;

namespace Sample.Data
{
    public class SampleEntities : DbContext
    {
        public SampleEntities() : base("SampleEntities") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());
        }
    }
}
