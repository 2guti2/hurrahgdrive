using System.Web.Mvc;

namespace Hurrah.GoogleDrive.Web.Controllers
{
    public class AboutController : GoogleDriveControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}