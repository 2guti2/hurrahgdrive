using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Hurrah.GoogleDrive.EntityFramework.Repositories
{
    public abstract class GoogleDriveRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<GoogleDriveDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected GoogleDriveRepositoryBase(IDbContextProvider<GoogleDriveDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class GoogleDriveRepositoryBase<TEntity> : GoogleDriveRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected GoogleDriveRepositoryBase(IDbContextProvider<GoogleDriveDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
