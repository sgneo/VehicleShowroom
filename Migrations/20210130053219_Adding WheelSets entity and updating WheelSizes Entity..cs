using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleShowroom.Migrations
{
    public partial class AddingWheelSetsentityandupdatingWheelSizesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "WheelSet");

            migrationBuilder.AddColumn<int>(
                name: "WheelSizeID",
                table: "WheelSet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WheelSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<decimal>(type: "decimal(6, 1)", nullable: false),
                    SizeName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelSize", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WheelSet_WheelSizeID",
                table: "WheelSet",
                column: "WheelSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WheelSet_WheelSize_WheelSizeID",
                table: "WheelSet",
                column: "WheelSizeID",
                principalTable: "WheelSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WheelSet_WheelSize_WheelSizeID",
                table: "WheelSet");

            migrationBuilder.DropTable(
                name: "WheelSize");

            migrationBuilder.DropIndex(
                name: "IX_WheelSet_WheelSizeID",
                table: "WheelSet");

            migrationBuilder.DropColumn(
                name: "WheelSizeID",
                table: "WheelSet");

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "WheelSet",
                type: "decimal(6, 1)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
