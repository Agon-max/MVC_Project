using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantWebApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class Connections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodTypeId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodTypeId",
                table: "Foods",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodTypes_FoodTypeId",
                table: "Foods",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodTypes_FoodTypeId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FoodTypeId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodTypeId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Foods");
        }
    }
}
