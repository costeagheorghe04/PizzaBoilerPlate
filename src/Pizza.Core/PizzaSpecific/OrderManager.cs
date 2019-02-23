using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Pizza.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Pizza.PizzaSpecific
{
   public class OrderManager 
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<OrderLine, Guid> _orderLineRepository;

        public OrderManager(IRepository<Order, Guid> orderrepository,
           IRepository<OrderLine, Guid> orderlinerepository)
        {
            _orderRepository = orderrepository;
            _orderLineRepository = orderlinerepository;
            EventBus = NullEventBus.Instance;
        }

        public async Task CreateAsync(User user)
        {
            if (await GetCurrentOrderForUser(user) == null)
            {
                await _orderRepository.InsertAsync(Order.Create(user.TenantId.Value, user.Id));
            }
            else throw new UserFriendlyException("Allready existing order");
        }

        public async Task AddOrderLineAsync(Order order, User user, int quantity, Product product)
        {
            if (user.Id != order.CreatorUserId)
                throw new UserFriendlyException("Cannot add to an order created by a different user");

            var orderLine = order.AddOrderLine(quantity, product, user.Id);
            
            await _orderRepository.UpdateAsync(order);            
        }

        public async Task<Order> GetCurrentOrderForUser(User user)
        {
            return await _orderRepository.GetAllIncluding(o => o.OrderLines)
                .FirstOrDefaultAsync(o => o.CreatorUserId == user.Id);
        }
        public async Task<Order> ConfirmOrder(Order order)
        {
            order.Confirm();
            return await _orderRepository.UpdateAsync(order);
        }
    }
}
