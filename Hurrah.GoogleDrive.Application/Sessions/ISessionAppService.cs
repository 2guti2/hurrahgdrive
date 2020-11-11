using System.Threading.Tasks;
using Abp.Application.Services;
using Hurrah.GoogleDrive.Sessions.Dto;

namespace Hurrah.GoogleDrive.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
