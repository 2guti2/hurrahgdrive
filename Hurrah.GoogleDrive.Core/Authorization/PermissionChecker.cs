using Abp.Authorization;
using Hurrah.GoogleDrive.Authorization.Roles;
using Hurrah.GoogleDrive.Authorization.Users;

namespace Hurrah.GoogleDrive.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
