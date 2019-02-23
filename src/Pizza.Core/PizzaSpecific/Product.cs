using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza.PizzaSpecific
{
    [Table("Product")]
    public class Product : FullAuditedEntity<Guid>, IMustHaveTenant

    {
        public const int MaxNameLength = 128;
        public const int MaxDescriptionLength = 2048;

        public virtual int TenantId { get;  set; }

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; protected set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; protected set; }

        [Url]
        public virtual string PictureUrl { get; protected set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public virtual double Price { get; protected set; }
 
        protected Product() { }
       
        public static Product Create(int tenantId, string name, double price, 
            string description = null, string pictureUrl= null)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Name = name,
                Price = price,
                Description = description,
                PictureUrl = pictureUrl
            };
            return product;
        }
    }
    
}
