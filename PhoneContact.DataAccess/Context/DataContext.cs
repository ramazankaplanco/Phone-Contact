#region 

using PhoneContact.Entities;
using PhoneContact.Entities.Base;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace PhoneContact.DataAccess.Context
{
    public class DataContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public DataContext() : base(@"PhoneContact")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataContextMigrationConfiguration>());
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        public override IDbSet<User> Users { get; set; }
        public override IDbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
        }

        public override int SaveChanges()
        {
            try
            {
                var entries = ChangeTracker.Entries<EntityBase>()
                    .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified || p.State == EntityState.Deleted).ToArray();

                foreach (var entry in entries)
                {
                    var entity = entry.Entity;

                    switch (entry.State)
                    {
                        case EntityState.Detached:
                        case EntityState.Unchanged:
                            throw new Exception(nameof(entry.State));

                        case EntityState.Added:
                            break;
                        case EntityState.Modified:
                            break;
                        case EntityState.Deleted:
                        {
                            entity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                        }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(entry.State));
                    }
                }

                var result = base.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());

                throw;
            }
        }
    }
}