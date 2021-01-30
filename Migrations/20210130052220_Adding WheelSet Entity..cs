using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleShowroom.Migrations
{
    public partial class AddingWheelSetEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WheelSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(maxLength: 30, nullable: false),
                    Size = table.Column<decimal>(type: "decimal(6, 1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelSet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheelSet");
        }
    }
}
