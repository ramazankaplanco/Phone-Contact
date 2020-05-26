#region

using System.Data.Entity.Migrations;
using System.Linq;
using PhoneContact.Entities;

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

        protected override void Seed(DataContext context)
        {
            if (!context.Users.Any())
                context.Users.AddOrUpdate(new User
                {
                    Name = "System",
                    LastName = "Admin",
                    NickName = "admin",
                    Password = "admin"
                });

            base.Seed(context);
        }
    }
}