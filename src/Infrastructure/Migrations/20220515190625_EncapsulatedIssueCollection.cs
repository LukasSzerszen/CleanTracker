using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class EncapsulatedIssueCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                column: "AssignedTo",
                value: new Guid("94426296-f708-45a9-a315-7c9c8d6bde8f"));

            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("d5bf8c94-f7f3-4aaa-85fc-b02efd4a6d89"),
                column: "AssignedTo",
                value: new Guid("94426296-f708-45a9-a315-7c9c8d6bde8f"));

            migrationBuilder.UpdateData(
                table: "Sprint",
                keyColumn: "Id",
                keyValue: new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 29, 19, 6, 24, 515, DateTimeKind.Utc).AddTicks(2253), new DateTime(2022, 5, 15, 19, 6, 24, 515, DateTimeKind.Utc).AddTicks(749) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298"),
                column: "AssignedTo",
                value: new Guid("9925232a-7eb8-46bd-a1e9-597e06b36069"));

            migrationBuilder.UpdateData(
                table: "Issue",
                keyColumn: "IssueId",
                keyValue: new Guid("d5bf8c94-f7f3-4aaa-85fc-b02efd4a6d89"),
                column: "AssignedTo",
                value: new Guid("9925232a-7eb8-46bd-a1e9-597e06b36069"));

            migrationBuilder.UpdateData(
                table: "Sprint",
                keyColumn: "Id",
                keyValue: new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 21, 14, 12, 12, 650, DateTimeKind.Utc).AddTicks(9001), new DateTime(2022, 5, 7, 14, 12, 12, 650, DateTimeKind.Utc).AddTicks(7562) });
        }
    }
}
