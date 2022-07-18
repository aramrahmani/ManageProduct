using Sample.Data;
using Sample.Model;
using System.Collections.Generic;

namespace Sample.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public Product GetProduct(long productId)
        {
            return productRepository.GetById(productId);
        }

        public bool IsRepitiveProduct(long productId, string productName)
        {
            var entity = productRepository.GetProductByName(productName);
            return (entity != null && entity.ProductId != productId);
        }

        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product);
        }

        public void DeleteProduct(long productId)
        {
            var product = GetProduct(productId);
            DeleteProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }
        public void SaveProduct()
        {
            unitOfWork.Commit();
        }

        
    }
}
