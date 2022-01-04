using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdkManager.Data.Migrations
{
    public partial class Vpns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f0c1834-78b2-481e-a146-1eb659e15022");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85e000ae-5e55-4425-a33e-2560e0537489");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9299ba3c-87a2-4156-914a-3003603e3798");

            migrationBuilder.CreateTable(
                name: "Vpc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VpcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnableDnsHostnames = table.Column<bool>(type: "bit", nullable: true),
                    EnableDnsSupport = table.Column<bool>(type: "bit", nullable: true),
                    StackId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vpc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vpc_Stack_StackId",
                        column: x => x.StackId,
                        principalTable: "Stack",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "678a66d4-0851-4cc7-9396-7e14006846b2", "363cf371-435a-424f-9636-c4ef089480f9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b30b8f70-2edb-4ccc-928d-8a0a8613dc27", "396da44a-69d1-41ae-bba6-f217e69e21db", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de58639a-3d79-471e-9b26-6d2f8f9a2c23", "d1216ce5-241d-4ae4-a426-f6c3937eed2e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Vpc_StackId",
                table: "Vpc",
                column: "StackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vpc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "678a66d4-0851-4cc7-9396-7e14006846b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b30b8f70-2edb-4ccc-928d-8a0a8613dc27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de58639a-3d79-471e-9b26-6d2f8f9a2c23");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f0c1834-78b2-481e-a146-1eb659e15022", "6540de3a-ab0c-471a-8fe9-62c635a2424e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85e000ae-5e55-4425-a33e-2560e0537489", "4f9186e7-ecc7-4f5d-b15e-d884c1873d81", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9299ba3c-87a2-4156-914a-3003603e3798", "33ff7ad3-dcb5-4dc6-8c87-9ba64442262c", "Visitor", "VISITOR" });
        }
    }
}
