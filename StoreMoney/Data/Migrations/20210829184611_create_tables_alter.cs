using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreMoney.Data.Migrations
{
    public partial class create_tables_alter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StoreMoney",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StoreMoney");
        }
    }
}
