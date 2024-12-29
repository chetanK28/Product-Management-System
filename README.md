# Product Management System

## Overview
The **Product Management System** is a software application designed to manage product inventory and details efficiently. It provides functionality for creating, reading, updating, and deleting (CRUD) product records. This system utilizes a MySQL database for storage and retrieval, with a C# backend for business logic.

## Features
- Add new products.
- Retrieve all product details.
- Update existing product information.
- Delete product records.
- Validation for required fields such as Title, Description, Quantity, and Price.

## Technologies Used
- **Programming Language**: C#
- **Framework**: .NET
- **Database**: MySQL
- **ORM/Database Connector**: MySql.Data.MySqlClient

## Prerequisites
- Visual Studio 2022 or later
- MySQL Server and MySQL Workbench
- .NET 6.0 SDK or later

## Database Setup
1. Install MySQL Server if not already installed.
2. Create the `Product` table using the following SQL script:

   ```sql
   CREATE TABLE Product (
       Id INT AUTO_INCREMENT PRIMARY KEY,
       Title VARCHAR(100) NOT NULL,
       Description VARCHAR(500) NOT NULL,
       Quantity INT NOT NULL,
       Price DECIMAL(10, 2) NOT NULL
   );
   ```

3. Note down your database credentials (host, username, password, and database name).
4. Update the `connectionString` in the `ProductRepository` class with your database details.

   Example:
   ```csharp
   private readonly string connectionString = "Server=localhost;Database=ProductDB;Uid=root;Pwd=password;";
   ```

## Installation
1. Clone the repository:
   ```bash
   git clone  https://github.com/chetanK28/Product-Management-System.git
   ```
2. Open the project in Visual Studio.
3. Restore NuGet packages.
4. Build the solution.

## Usage
1. Run the application from Visual Studio.
2. Use the provided methods in the `ProductRepository` class to perform CRUD operations:
   - `AddProduct(Product product)`
   - `GetAllProduct()`
   - `GetProductById(int id)`
   - `UpdateProduct(Product product)`
   - `DeleteProduct(int productId)`

## Example
### Adding a New Product
```csharp
Product product = new Product
{
    Title = "Laptop",
    Description = "High-performance laptop",
    Quantity = 10,
    Price = 75000.00
};

ProductRepository repo = new ProductRepository(connectionString);
repo.AddProduct(product);
```

### Fetching All Products
```csharp
ProductRepository repo = new ProductRepository(connectionString);
var products = repo.GetAllProduct();
foreach (var product in products)
{
    Console.WriteLine($"{product.Id}: {product.Title} - {product.Price}");
}
```

## Project Structure
```
ProductManagementSystem
├── Models
│   └── Product.cs
├── Repositories
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
└── Program.cs
```

## Future Enhancements
- Implement a front-end UI for better interaction.
- Add authentication and authorization.
- Integrate RESTful APIs.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Author
- **Chetan Kirange**

