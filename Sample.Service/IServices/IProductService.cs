using Sample.Model;
using System.Collections.Generic;

namespace Sample.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(long productId);

        bool IsRepitiveProduct(long productId, string productName);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        void DeleteProduct(long productId);
        void SaveProduct();
    }
}
