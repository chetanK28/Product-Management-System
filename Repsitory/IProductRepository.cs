using ProductManagementSystem.Models;
using System.Collections;


namespace ProductManagementSystem.Repositories
{
    public interface IProductRepository
    {

        public void AddProduct(Product product);

        public void DeleteProduct(int ProductID);

        public void UpdateProduct(Product product);

        public Product GetProductById(int id);

        public IEnumerable GetAllProduct();

    }
}

