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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "IssueId", "AssignedTo", "Description", "Points", "Status", "Title" },
                values: new object[] { new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"), new Guid("53535aa8-12b6-4d67-bc9e-93fbc9bea802"), "description2", 2, "NotStarted", "issue2" });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "IssueId", "AssignedTo", "Description", "Points", "Status", "Title" },
                values: new object[] { new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890"), null, "description1", 1, "NotStarted", "issue1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");
        }
    }
}
