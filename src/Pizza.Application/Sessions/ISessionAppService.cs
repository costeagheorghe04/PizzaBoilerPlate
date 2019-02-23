using System.Threading.Tasks;
using Abp.Application.Services;
using Pizza.Sessions.Dto;

namespace Pizza.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
