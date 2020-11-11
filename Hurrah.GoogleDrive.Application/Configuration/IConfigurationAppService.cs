using System.Threading.Tasks;
using Abp.Application.Services;
using Hurrah.GoogleDrive.Configuration.Dto;

namespace Hurrah.GoogleDrive.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}