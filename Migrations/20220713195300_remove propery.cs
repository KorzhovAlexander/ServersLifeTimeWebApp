using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServersLifeTimeWebApp.Migrations
{
    public partial class removepropery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedForRemove",
                table: "Servers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SelectedForRemove",
                table: "Servers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
