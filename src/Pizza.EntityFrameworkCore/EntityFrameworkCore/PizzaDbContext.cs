using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Pizza.Authorization.Roles;
using Pizza.Authorization.Users;
using Pizza.MultiTenancy;

namespace Pizza.EntityFrameworkCore
{
    public class PizzaDbContext : AbpZeroDbContext<Tenant, Role, User, PizzaDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            : base(options)
        {
        }
    }
}
