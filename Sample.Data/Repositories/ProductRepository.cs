using Sample.Data;
using Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Product GetProductByName(string productName)
        {
            return DbContext.Products.Where(p => p.ProductName == productName).FirstOrDefault();
        }

        public override void Update(Product entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductByName(string productName);
    }
}
