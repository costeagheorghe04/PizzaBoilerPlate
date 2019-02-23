
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.PizzaSpecific
{
    public class OrderLine : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
       
        [Required]
        public virtual int Quantity { get; protected set; }

        [ForeignKey("ProductId")]
        public virtual Guid ProductId { get; protected set; }
        public virtual Product Product { get; protected set; }

        [ForeignKey("OrderId")]
        public virtual Guid OrderId { get; protected set; }
        public virtual Order Order { get; protected set; }

        protected OrderLine(){ }  

        public static OrderLine Create(int tenantId, int quantity,Product product, Guid orderId)
        {
            var orderLine = new OrderLine
            {  
                Id= Guid.NewGuid(),
                TenantId = tenantId,
                Quantity = quantity,
                Product = product,
                ProductId = product.Id,
                OrderId = orderId
            };
            return orderLine;
        }

    }
}
