using Entities.Dtos.Order;
using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> Orders { get; }
        OrderDto? GetOneOrder(Guid id);
        IEnumerable<Order> GetUsersOrders(string userId);
        void Complete(Guid id);
        void SaveOrder(OrderDto order, string userId);
        int NumberOfInProcess { get; }
    }
}
