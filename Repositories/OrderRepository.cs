using Entities.Models;
using Entities.Models.Common;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Status);

        public IQueryable<Order> GetUsersOrders(string userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Lines)
                .ThenInclude(cl => cl.Product)
                .OrderByDescending(o => o.OrderedAt);
        }

        public int NumberOfInProcess =>
            _context.Orders.Count(o => o.Status == OrderStatus.Pending);

        public void Complete(Guid id)
        {
            var order = FindByCondition(o => o.Id.Equals(id), true);
            if (order is null)
                throw new Exception("Order could not found!");
            order.Status = OrderStatus.Delivered;
        }

        public Order? GetOneOrder(Guid id)
        {
            return FindByCondition(o => o.Id.Equals(id), false);
        }

        public void SaveOrder(Order order, string userId)
        {
            order.UserId = userId;

            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == Guid.Empty)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
