using System.Threading.Tasks;
using Pizza.Configuration.Dto;

namespace Pizza.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
