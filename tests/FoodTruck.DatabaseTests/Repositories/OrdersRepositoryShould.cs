using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using Xunit;
using FoodTruck.Domain.Repositories;
using FoodTruck.Infrastructure.Repositories;
using FoodTruck.DatabaseTests.Seeders;
namespace FoodTruck.DatabaseTests;

public class OrdersRepositoryShould
{
    // Run EF Migrations\DBUp script to prepare database before running your tests.
    const string ConnectionString = "Data Source=database;Initial Catalog=master;PersistSecurityInfo=True;User ID=sa;Password=P@ssW0rd!";

    [Fact]
    public async Task GetOrdersFromDatabase()
    {
        //Arrange
        await OrderSeeder.SeedOrdersData(ConnectionString);
        var ordersRepository = new OrdersRepository(ConnectionString);

        //Act
        var orders = (await ordersRepository.GetOrders()).ToList();
        
        //Assert
        orders.Should().NotBeEmpty();
        orders.ForEach(o => o.Quantity.Should().BeGreaterThan(0));
    }
}