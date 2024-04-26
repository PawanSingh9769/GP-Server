using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductifyBackend.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d6cbc2b-6bf9-46ed-8395-f653ec93a320", "a62b61b2-6610-48b9-8e49-3f45b8ce9ed9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "352de9f3-ad05-443b-b3fe-2b74cf1cf282", "2691fce1-9e46-495f-8dda-ee34b9ee318d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d6cbc2b-6bf9-46ed-8395-f653ec93a320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "352de9f3-ad05-443b-b3fe-2b74cf1cf282");
        }
    }
}
