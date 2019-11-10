using Microsoft.EntityFrameworkCore.Migrations;
using brendan_tests;

namespace brendan_tests.Migrations
{
    public partial class JsonData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TextEntityData>(
                name: "Data",
                table: "TestEntities",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "TestEntities");
        }
    }
}
