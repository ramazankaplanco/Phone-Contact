#region 

using PhoneContact.Entities;
using PhoneContact.Entities.Base;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

#endregion

namespace PhoneContact.DataAccess.Context
{
	public class DataContext : DbContext
	{
		public DataContext() : base(@"PhoneContact")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataContextMigrationConfiguration>());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
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
			try
			{
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