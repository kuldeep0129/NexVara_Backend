using Microsoft.AspNetCore.Identity;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedSuperAdmin(userManager);
            await SeedAdmin(userManager);
            await SeedSalesDepartment(userManager);
        }
        private static async Task SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            string[] roles = { Roles.SuperAdmin.ToString(), Roles.Admin.ToString() ,Roles.Sales.ToString()};

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole
                    {
                        Name = role
                    });
                }
            }
        }
        private static async Task SeedSuperAdmin(UserManager<ApplicationUser> userManager)
        {
            var email = "superadmin@nexvara.com";

            if (await userManager.FindByEmailAsync(email) != null)
                return;

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = "Super",
                LastName = "Admin",
                IsActive = true
            };

            await userManager.CreateAsync(user, "Super@123");

            await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
        }
        private static async Task SeedAdmin(UserManager<ApplicationUser> userManager)
        {
            var email = "admin@nexvara.com";

            if (await userManager.FindByEmailAsync(email) != null)
                return;

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Admin"
            };

            await userManager.CreateAsync(user, "Admin@123");

            await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
        }
        private static async Task SeedSalesDepartment(UserManager<ApplicationUser> userManager)
        {
            var email = "Sales@nexvara.com";

            if (await userManager.FindByEmailAsync(email) != null)
                return;

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = "Sales",
                LastName = "Department"
            };

            await userManager.CreateAsync(user, "Sales@123");

            await userManager.AddToRoleAsync(user, Roles.Sales.ToString());
        }
    }
}
