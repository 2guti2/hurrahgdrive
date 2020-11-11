using Hurrah.GoogleDrive.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Hurrah.GoogleDrive.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly GoogleDriveDbContext _context;

        public InitialHostDbBuilder(GoogleDriveDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
