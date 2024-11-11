using Entities.Dtos.Order;
using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> Orders { get; }
        OrderDto? GetOneOrder(Guid id);
        void Complete(Guid id);
        void SaveOrder(OrderDto order);
        int NumberOfInProcess { get; }
    }
}
