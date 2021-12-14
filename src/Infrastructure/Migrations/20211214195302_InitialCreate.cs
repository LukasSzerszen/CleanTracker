using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "IssueId", "AssignedTo", "Description", "Points", "Status", "Title" },
                values: new object[] { new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"), new Guid("c571342a-74f3-4c60-b39a-4b7625aea957"), "description2", 2, "0", "issue2" });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "IssueId", "AssignedTo", "Description", "Points", "Status", "Title" },
                values: new object[] { new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890"), new Guid("00000000-0000-0000-0000-000000000000"), "description1", 1, "0", "issue1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");
        }
    }
}
