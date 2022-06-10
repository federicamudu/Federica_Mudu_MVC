using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyF.TestWeek7.RepositoryEF.Migrations
{
    public partial class CambioRequiredInFalseFKMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Menu_Id",
                table: "Dish");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Menu_Id",
                table: "Dish",
                column: "Id",
                principalTable: "Menu",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Menu_Id",
                table: "Dish");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Menu_Id",
                table: "Dish",
                column: "Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
