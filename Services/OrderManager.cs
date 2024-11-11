using AutoMapper;
using Entities.Dtos.Order;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<Order> Orders => _repositoryManager.Order.Orders;

        public int NumberOfInProcess => _repositoryManager.Order.NumberOfInProcess;

        public void Complete(Guid id)
        {
            _repositoryManager.Order.Complete(id);
            _repositoryManager.Save();
        }

        public OrderDto? GetOneOrder(Guid id)
        {
            var order = _repositoryManager.Order.GetOneOrder(id);
            return _mapper.Map<OrderDto>(order);
        }

        public void SaveOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            _repositoryManager.Order.SaveOrder(order);
        }
    }
}
