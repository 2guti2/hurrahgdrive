using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Hurrah.GoogleDrive.EntityFramework;

namespace Hurrah.GoogleDrive
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(GoogleDriveCoreModule))]
    public class GoogleDriveDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GoogleDriveDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
