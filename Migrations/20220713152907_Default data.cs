using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServersLifeTimeWebApp.Migrations
{
    public partial class Defaultdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreateDateTime", "SelectedForRemove", "RemoveDateTime" },
                values: new object[] { 1, new DateTime(2019, 1, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2019, 1, 21, 16, 40, 35, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "CreateDateTime", "SelectedForRemove", "RemoveDateTime" },
                values: new object[] { 2, new DateTime(2019, 1, 21, 12, 40, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2019, 1, 21, 16, 40, 35, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
