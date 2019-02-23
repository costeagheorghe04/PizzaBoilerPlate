using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pizza.Configuration;
using Pizza.Web;

namespace Pizza.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PizzaDbContextFactory : IDesignTimeDbContextFactory<PizzaDbContext>
    {
        public PizzaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PizzaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PizzaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PizzaConsts.ConnectionStringName));

            return new PizzaDbContext(builder.Options);
        }
    }
}
