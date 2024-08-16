using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FoodTruck.Domain.Models;
using System.Collections.Generic;
using FoodTruck.Domain.Repositories;
namespace FoodTruck.Infrastructure.Repositories;
/// <summary>
/// This implementation wont live in domain, this is simply to allow testing another project 
/// </summary>
public class OrdersRepository : IOrdersRepository
{
    private readonly string _connectionString;
    public OrdersRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task<IEnumerable<Order>> GetOrders()
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            const string query = "SELECT Id, Quantity FROM Orders";
            var orders = await conn.QueryAsync<Order>(query);
            
            return orders.ToList();

        }
    }
}