using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactStaterKitApi.Migrations
{
    public partial class AddSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Email", "FirstName", "LastName", "Username" },
                values: new object[] { 1, null, "xuantuan93@gmail.com", "Tuan", "Nguyen", "Tuan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Email", "FirstName", "LastName", "Username" },
                values: new object[] { 2, null, "baoduy2412@outlook.com", "Steven", "Hoang", "Steven" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
