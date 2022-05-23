using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedSprints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sprint",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[] { new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591"), new DateTime(2022, 5, 21, 14, 12, 12, 650, DateTimeKind.Utc).AddTicks(9001), new DateTime(2022, 5, 7, 14, 12, 12, 650, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                columns: new[] { "AssignedTo", "SprintId" },
                values: new object[] { new Guid("9925232a-7eb8-46bd-a1e9-597e06b36069"), new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591") });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "IssueId", "AssignedTo", "Description", "Points", "SprintId", "Status", "Title" },
                values: new object[] { new Guid("d5bf8c94-f7f3-4aaa-85fc-b02efd4a6d89"), new Guid("9925232a-7eb8-46bd-a1e9-597e06b36069"), "description3", 4, new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591"), "NotStarted", "issue3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("d5bf8c94-f7f3-4aaa-85fc-b02efd4a6d89"));

            migrationBuilder.DeleteData(
                table: "Sprint",
                keyColumn: "Id",
                keyValue: new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591"));

            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                columns: new[] { "AssignedTo", "SprintId" },
                values: new object[] { new Guid("cb1c520b-6085-4d31-8203-85b0afe538e2"), null });
        }
    }
}
