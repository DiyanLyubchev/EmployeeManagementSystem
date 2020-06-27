using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystemData.Migrations
{
    public partial class fix_salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                column: "ConcurrencyStamp",
                value: "7dee84ef-0bfb-40d8-8891-5d8e497c5043");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69e7930c-3df5-4261-99cf-0352eb018a91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7eeb93b3-7339-491e-babb-e84380589e44", "AQAAAAEAACcQAAAAENg5iYatb4TiawKnL/0uOe5IbE+Gpqj1/Jg82EP3EawxaUBc8VrneNQjKHo/JdLWYg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                column: "ConcurrencyStamp",
                value: "8985482e-47eb-47ff-bdfd-2fa7060c76b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69e7930c-3df5-4261-99cf-0352eb018a91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6b0b252-875d-48d7-81b5-2549ca3360ec", "AQAAAAEAACcQAAAAEGDM9jSClSEP1M4/DuQbLWnk0+Ej1dKMkQbYhR9SR3d3n+qHncHi9edIDm0diNrBig==" });
        }
    }
}
