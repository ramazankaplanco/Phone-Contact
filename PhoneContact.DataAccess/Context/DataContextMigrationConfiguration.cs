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
            {
                var user = context.Users.Add(new User
                {
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = "AJti4fwF8EyR3eHeB+7gGtV0MaoiV8/s++CLy0hnZcL2cSg/wU061Q9oxXBJO1RFRg==",
                    SecurityStamp = "61c9ab25-a352-42a0-876f-2e26269c25b1"
                });

                var role = context.Roles.Add(new Role
                {
                    Name = "Admin"
                });

                var userRole = context.UserRoles.Add(new UserRole
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });


                context.Departments.AddOrUpdate(new Department
                {
                    Code = "IT01",
                    Name = "IT"
                });

                context.Employees.Add(new Employee
                {
                    Name = "R.",
                    LastName = "Tiger",
                    Phone = "+90 552 111 11 11"
                });
            }
            base.Seed(context);
        }
    }
}