using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductifyBackend.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d6cbc2b-6bf9-46ed-8395-f653ec93a320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "352de9f3-ad05-443b-b3fe-2b74cf1cf282");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "205e5d58-0d68-473f-8bd4-930479aec490", "e084729f-3447-46d5-8444-ef276d83d659", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee52894b-582b-454f-81d8-883c8a94a2c2", "0259cb69-a8e2-4efd-aac5-0bd4f7f33de8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "205e5d58-0d68-473f-8bd4-930479aec490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee52894b-582b-454f-81d8-883c8a94a2c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d6cbc2b-6bf9-46ed-8395-f653ec93a320", "a62b61b2-6610-48b9-8e49-3f45b8ce9ed9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "352de9f3-ad05-443b-b3fe-2b74cf1cf282", "2691fce1-9e46-495f-8dda-ee34b9ee318d", "User", "USER" });
        }
    }
}
