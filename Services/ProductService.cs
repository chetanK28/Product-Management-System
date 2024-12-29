
        using ProductManagementSystem.Models;
        using ProductManagementSystem.Repositories;
        using ProductManagementSystem.Services;
        using System.Collections;
        using System.Collections.Generic;



        namespace ProductManagementSystem.Services
        {
            public class ProductService : IProductService
            {
                private IProductRepository productRepository;

                public ProductService(IProductRepository productRepository)
                {
                    this.productRepository = productRepository;
                }

                public void AddProduct(Product product)
                {
                    productRepository.AddProduct(product);
                }

                public void DeleteProduct(int productID)
                {
                    productRepository.DeleteProduct(productID);
                }

                public IEnumerable GetAllProduct()
                {
                    return productRepository.GetAllProduct();
                }

                public Product GetProductById(int id)
                {
                    return productRepository.GetProductById(id);
                }

                public void UpdateProduct(Product product)
                {
                    productRepository.UpdateProduct(product);
                }
            }
        }

