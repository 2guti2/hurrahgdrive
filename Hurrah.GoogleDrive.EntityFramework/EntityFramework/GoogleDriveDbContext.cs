﻿using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using Hurrah.GoogleDrive.Authorization.Roles;
using Hurrah.GoogleDrive.Authorization.Users;
using Hurrah.GoogleDrive.MultiTenancy;

namespace Hurrah.GoogleDrive.EntityFramework
{
    public class GoogleDriveDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public GoogleDriveDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in GoogleDriveDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of GoogleDriveDbContext since ABP automatically handles it.
         */
        public GoogleDriveDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public GoogleDriveDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public GoogleDriveDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
