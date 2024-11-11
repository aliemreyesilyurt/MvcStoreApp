using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(Guid id);
        void Complete(Guid id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; }
    }
}
