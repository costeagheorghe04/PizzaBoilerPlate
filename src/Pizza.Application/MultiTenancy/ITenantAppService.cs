using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pizza.MultiTenancy.Dto;

namespace Pizza.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

