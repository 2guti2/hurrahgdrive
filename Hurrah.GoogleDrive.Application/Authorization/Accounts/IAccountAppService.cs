using System.Threading.Tasks;
using Abp.Application.Services;
using Hurrah.GoogleDrive.Authorization.Accounts.Dto;

namespace Hurrah.GoogleDrive.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
