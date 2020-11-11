using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hurrah.GoogleDrive.MultiTenancy.Dto;

namespace Hurrah.GoogleDrive.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
