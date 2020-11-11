using System.Linq;
using Hurrah.GoogleDrive.EntityFramework;
using Hurrah.GoogleDrive.MultiTenancy;

namespace Hurrah.GoogleDrive.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly GoogleDriveDbContext _context;

        public DefaultTenantCreator(GoogleDriveDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
