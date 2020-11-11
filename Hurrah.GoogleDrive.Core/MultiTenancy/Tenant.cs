using Abp.MultiTenancy;
using Hurrah.GoogleDrive.Authorization.Users;

namespace Hurrah.GoogleDrive.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}