using System.Threading.Tasks;
using FoodTruck.Domain.Models;
using System.Collections.Generic;
namespace FoodTruck.Domain.Repositories;
public interface IOrdersRepository
{
    Task<IEnumerable<Order>> GetOrders();
}