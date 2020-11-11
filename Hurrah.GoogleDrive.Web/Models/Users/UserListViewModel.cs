using System.Collections.Generic;
using Hurrah.GoogleDrive.Roles.Dto;
using Hurrah.GoogleDrive.Users.Dto;

namespace Hurrah.GoogleDrive.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}