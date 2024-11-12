using Entities.Models;

namespace Repositories.Contracts
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(Guid id);
        IQueryable<Order> GetUsersOrders(string userId);
        void Complete(Guid id);
        void SaveOrder(Order order, string userId);
        int NumberOfInProcess { get; }
    }
}
