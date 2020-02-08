using EmployeeManagementSystemData.Common;
using EmployeeManagementSystemData.Models.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementSystemData.Extentions
{
    public static class SeedEmployeeRoles
    {

        public static void EmployeeRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserRole>()
                .HasData(new UserRole
                {
                    Id = "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            var hasher = new PasswordHasher<User>();

            var adminDiyan = new User
            {
                Id = "69e7930c-3df5-4261-99cf-0352eb018a91",
                UserName = "diyan@admin.com",
                NormalizedUserName = "DIYAN@ADMIN.COM",
                Email = "diyan@admin.com",
                NormalizedEmail = "DIYAN@ADMIN.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true
            };


            adminDiyan.PasswordHash = hasher
                .HashPassword(adminDiyan, "123456");

            modelBuilder.Entity<User>()
                .HasData(adminDiyan);

            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                { UserId = adminDiyan.Id, RoleId = "77aedcd5-c539-40cd-b88e-e30ff108e6b8" });
        }
    }
}
