
using Sample.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Sample.Data
{
    public class SampleSeedData : DropCreateDatabaseAlways<SampleEntities>
    {
        protected override void Seed(SampleEntities context)
        {
            GetUnits().ForEach(u => context.Units.Add(u));
            GetProducts().ForEach(p => context.Products.Add(p));

            context.Commit();
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {
                    ProductName = "خودکار",
                    UnitId=1,
                    Count=10
                }
            };
        }

        private static List<Unit> GetUnits()
        {
            return new List<Unit>
            {
                new Unit {
                    UnitName = "تعداد",
                }
            };
        }
    }
}
