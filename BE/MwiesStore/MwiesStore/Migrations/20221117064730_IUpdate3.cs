using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MwiesStore.Migrations
{
    public partial class IUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BillDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
