using Abp.AutoMapper;
using Hurrah.GoogleDrive.Sessions.Dto;

namespace Hurrah.GoogleDrive.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}