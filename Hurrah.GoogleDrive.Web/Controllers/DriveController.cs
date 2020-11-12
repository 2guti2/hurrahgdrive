using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Hurrah.GoogleDrive.Web.Google;

namespace Hurrah.GoogleDrive.Web.Controllers
{
    [AbpMvcAuthorize]
    public class DriveController : GoogleDriveControllerBase
    {
        private AuthorizationCodeWebApp.AuthResult _authResult;

        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            if (_authResult == null)
                _authResult =
                    await new AuthorizationCodeMvcApp(this, new AppFlowMetadata())
                        .AuthorizeAsync(cancellationToken);

            if (_authResult.Credential == null) return new RedirectResult(_authResult.RedirectUri);
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _authResult.Credential,
                ApplicationName = "Hurrah! Google Drive"
            });

            const string fileId = "1Xudiwf12N5gN4FhkA7lOlsvYVmxhEwAcyipT4wRH5u8";

            ActionResult result = await DownloadFile(fileId, service, cancellationToken);

            ViewBag.Message = "File updated successfully";
            return result;
        }

        public ActionResult Index()
        {
            return View();
        }

        private async Task<ActionResult> DownloadFile(string fileId, DriveService service,
            CancellationToken cancellationToken)
        {
            const string excelMimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Stream excelStream = await service.Files.Export(fileId, excelMimeType)
                .ExecuteAsStreamAsync(cancellationToken);
            using (var fs = new FileStream("C:\\Develop\\hurrahgdrive\\test.xlsx", FileMode.CreateNew,
                FileAccess.Write, FileShare.None, 8 * 1024, true))
            {
                await excelStream.CopyToAsync(fs);
            }

            return View();
        }
    }
}