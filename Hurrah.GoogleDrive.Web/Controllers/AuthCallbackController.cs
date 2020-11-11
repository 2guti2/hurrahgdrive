using Google.Apis.Auth.OAuth2.Mvc;
using Hurrah.GoogleDrive.Web.Google;

namespace Hurrah.GoogleDrive.Web.Controllers
{
    public class AuthCallbackController : global::Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        protected override FlowMetadata FlowData => new AppFlowMetadata();
    }
}