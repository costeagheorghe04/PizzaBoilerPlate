using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Pizza.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.PizzaSpecific
{
    public class Order : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("CreatorUserId")]
        public virtual User CreatorUser { get; set; }

        public OrderStatus Status { get; set; }

        public double TotalPrice { get; set; }

        [ForeignKey("OrderId")]
        public virtual ICollection<OrderLine> OrderLines { get; protected set; }

        protected Order()
        {
            
        }

        public static Order Create(int tenantId, long userId)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreatorUserId = userId,
                TenantId = tenantId,
                OrderLines = new Collection<OrderLine>()
            };
            
            return order;
        }

        public OrderLine AddOrderLine(int quantity, Product product, long userId) {
            var orderLine = OrderLine.Create(TenantId, quantity, product , Id);
            OrderLines.Add(orderLine);
            TotalPrice += product.Price;
            LastModifierUserId = userId;
            return orderLine;
        }
        public void Confirm()
        {
            Status = OrderStatus.Paid;
         }
    }
}
