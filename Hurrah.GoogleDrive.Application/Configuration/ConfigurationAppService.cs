using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Hurrah.GoogleDrive.Configuration.Dto;

namespace Hurrah.GoogleDrive.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : GoogleDriveAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
