using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Sprints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Issue",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "SprintId",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                column: "AssignedTo",
                value: new Guid("cb1c520b-6085-4d31-8203-85b0afe538e2"));

            migrationBuilder.CreateIndex(
                name: "IX_Issue_SprintId",
                table: "Issue",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Sprint_SprintId",
                table: "Issue",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Sprint_SprintId",
                table: "Issue");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropIndex(
                name: "IX_Issue_SprintId",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Issue");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Issue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                column: "AssignedTo",
                value: new Guid("53535aa8-12b6-4d67-bc9e-93fbc9bea802"));
        }
    }
}
