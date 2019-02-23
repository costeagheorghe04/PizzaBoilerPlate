using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Pizza.EntityFrameworkCore
{
    public static class PizzaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PizzaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PizzaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
