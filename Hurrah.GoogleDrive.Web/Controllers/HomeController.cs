using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Hurrah.GoogleDrive.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : GoogleDriveControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}