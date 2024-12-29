using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }
       

        public Product() { }

        public Product( string title, string description, int quantity, double price)
        {
            
            Title = title;
            Description = description;
            Quantity = quantity;
            Price = price;
        }

        public Product(int ProductId, string title, string description, int quantity, double price)
        {
      
           Id = ProductId;
            Title = title;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
