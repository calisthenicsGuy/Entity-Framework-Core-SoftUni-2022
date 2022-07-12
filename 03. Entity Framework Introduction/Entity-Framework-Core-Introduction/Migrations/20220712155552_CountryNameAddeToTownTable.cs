using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Core_Introduction.Migrations
{
    public partial class CountryNameAddeToTownTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Towns",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Towns");
        }
    }
}
