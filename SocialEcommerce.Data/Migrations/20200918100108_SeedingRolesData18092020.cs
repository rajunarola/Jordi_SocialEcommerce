using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialEcommerce.Data.Migrations
{
    public partial class SeedingRolesData18092020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd2cb06f-776a-4797-bc8c-217947b11554", "8f7241a1-768c-4c77-b0ca-5758fc58ba79", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "873e6217-a76f-467f-a3ed-339021699a85", "f30db1f4-3746-4566-846c-47f3f4cf56ad", "Distributor", "DISTRIBUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb8e2150-2c35-4bb8-b14a-26c953367a4e", "d36ead47-c46d-488b-9498-a8fd8002eaef", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873e6217-a76f-467f-a3ed-339021699a85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb8e2150-2c35-4bb8-b14a-26c953367a4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd2cb06f-776a-4797-bc8c-217947b11554");
        }
    }
}
