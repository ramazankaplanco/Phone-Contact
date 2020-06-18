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
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = "AJti4fwF8EyR3eHeB+7gGtV0MaoiV8/s++CLy0hnZcL2cSg/wU061Q9oxXBJO1RFRg==",
                    SecurityStamp = "61c9ab25-a352-42a0-876f-2e26269c25b1"
                });

            base.Seed(context);
        }
    }
}