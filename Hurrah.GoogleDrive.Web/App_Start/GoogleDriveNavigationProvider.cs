using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Hurrah.GoogleDrive.Authorization;

namespace Hurrah.GoogleDrive.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class GoogleDriveNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu.AddItem(
                    new MenuItemDefinition(
                        "Drive",
                        L("drive"),
                        url: "drive/index",
                        icon: "folder",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                        )
                );
                // .AddItem(
                //     new MenuItemDefinition(
                //         PageNames.Tenants,
                //         L("Tenants"),
                //         url: "Tenants",
                //         icon: "business",
                //         permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                //     )
                // ).AddItem(
                //     new MenuItemDefinition(
                //         PageNames.Users,
                //         L("Users"),
                //         url: "Users",
                //         icon: "people",
                //         permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                //     )
                // ).AddItem(
                //     new MenuItemDefinition(
                //         PageNames.Roles,
                //         L("Roles"),
                //         url: "Roles",
                //         icon: "local_offer",
                //         permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                //     )
                // );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, GoogleDriveConsts.LocalizationSourceName);
        }
    }
}
