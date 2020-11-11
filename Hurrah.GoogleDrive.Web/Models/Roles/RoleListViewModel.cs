using System.Collections.Generic;
using Hurrah.GoogleDrive.Roles.Dto;

namespace Hurrah.GoogleDrive.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}