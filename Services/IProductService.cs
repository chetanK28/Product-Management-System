using System.Collections;

using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public interface IProductService
    {

        public void AddProduct(Product product);
        public void DeleteProduct(int productID);
        public void UpdateProduct(Product product);


        public Product GetProductById(int id);

        public IEnumerable GetAllProduct();




    }
}
