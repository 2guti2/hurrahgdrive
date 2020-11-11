using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Hurrah.GoogleDrive.EntityFramework;

namespace Hurrah.GoogleDrive.Migrator
{
    [DependsOn(typeof(GoogleDriveDataModule))]
    public class GoogleDriveMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<GoogleDriveDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}