using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Pizza.Configuration;

namespace Pizza.Web.Host.Startup
{
    [DependsOn(
       typeof(PizzaWebCoreModule))]
    public class PizzaWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PizzaWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PizzaWebHostModule).GetAssembly());
        }
    }
}
