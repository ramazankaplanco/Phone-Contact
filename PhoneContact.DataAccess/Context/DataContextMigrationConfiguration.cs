#region 

using System.Data.Entity.Migrations;

#endregion

namespace PhoneContact.DataAccess.Context
{
	public class DataContextMigrationConfiguration : DbMigrationsConfiguration<DataContext>
	{
		public DataContextMigrationConfiguration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}
	}
}