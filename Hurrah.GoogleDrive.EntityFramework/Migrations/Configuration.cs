using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Hurrah.GoogleDrive.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace Hurrah.GoogleDrive.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<GoogleDrive.EntityFramework.GoogleDriveDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GoogleDrive";
        }

        protected override void Seed(GoogleDrive.EntityFramework.GoogleDriveDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
