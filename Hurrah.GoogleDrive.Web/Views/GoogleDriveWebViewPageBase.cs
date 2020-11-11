using Abp.Web.Mvc.Views;

namespace Hurrah.GoogleDrive.Web.Views
{
    public abstract class GoogleDriveWebViewPageBase : GoogleDriveWebViewPageBase<dynamic>
    {

    }

    public abstract class GoogleDriveWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected GoogleDriveWebViewPageBase()
        {
            LocalizationSourceName = GoogleDriveConsts.LocalizationSourceName;
        }
    }
}