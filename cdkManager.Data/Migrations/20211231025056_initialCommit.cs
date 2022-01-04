using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdkManager.Data.Migrations
{
    public partial class initialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StackName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deployed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bucket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BucketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BucketKeyEnabled = table.Column<bool>(type: "bit", nullable: true),
                    EnforceSSL = table.Column<bool>(type: "bit", nullable: true),
                    PublicReadAccess = table.Column<bool>(type: "bit", nullable: true),
                    ServerAccessLogsPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferAcceleration = table.Column<bool>(type: "bit", nullable: true),
                    Versioned = table.Column<bool>(type: "bit", nullable: true),
                    WebsiteErrorDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteIndexDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bucket_Stack_StackId",
                        column: x => x.StackId,
                        principalTable: "Stack",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Bucket_StackId",
                table: "Bucket",
                column: "StackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bucket");

            migrationBuilder.DropTable(
                name: "Stack");

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
        }
    }
}
