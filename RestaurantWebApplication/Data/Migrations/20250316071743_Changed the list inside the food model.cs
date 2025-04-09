using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantWebApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changedthelistinsidethefoodmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Foods_FoodId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FoodId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Foods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodId",
                table: "Foods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Foods_FoodId",
                table: "Foods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }
    }
}
