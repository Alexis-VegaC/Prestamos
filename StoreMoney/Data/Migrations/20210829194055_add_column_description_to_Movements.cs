using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreMoney.Data.Migrations
{
    public partial class add_column_description_to_Movements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");
        }
    }
}
