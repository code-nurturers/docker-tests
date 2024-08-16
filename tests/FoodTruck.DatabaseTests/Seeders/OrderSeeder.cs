using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace FoodTruck.DatabaseTests.Seeders;

public static class OrderSeeder
{
    public static async Task SeedOrdersData(string connectionString)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();
            const string createOrderTable = @"
            CREATE TABLE orders (
                id INT PRIMARY KEY,
                customer_name VARCHAR(100),
                product_name VARCHAR(100),
                quantity INT,
                price DECIMAL(10, 2),
                order_date DATE
            );";
            var tableCreationResult = await conn.ExecuteAsync(createOrderTable);
            

            const string insertOrders = @"
            INSERT INTO orders (id, customer_name, product_name, quantity, price, order_date) VALUES
                (1, 'John Doe', 'Laptop', 1, 999.99, '2024-08-01'),
                (2, 'Jane Smith', 'Smartphone', 2, 599.99, '2024-08-02'),
                (3, 'Alice Johnson', 'Tablet', 3, 299.99, '2024-08-03'),
                (4, 'Bob Brown', 'Monitor', 2, 199.99, '2024-08-04'),
                (5, 'Charlie Wilson', 'Keyboard', 4, 49.99, '2024-08-05'),
                (6, 'Diana Miller', 'Mouse', 5, 25.99, '2024-08-06'),
                (7, 'Eve Davis', 'Printer', 1, 149.99, '2024-08-07'),
                (8, 'Frank Garcia', 'External Hard Drive', 2, 89.99, '2024-08-08'),
                (9, 'Grace Lee', 'USB Flash Drive', 10, 9.99, '2024-08-09'),
                (10, 'Henry Clark', 'Webcam', 1, 59.99, '2024-08-10');
            ";
            var affectedRows = await conn.ExecuteAsync(insertOrders);

        }
    }
}