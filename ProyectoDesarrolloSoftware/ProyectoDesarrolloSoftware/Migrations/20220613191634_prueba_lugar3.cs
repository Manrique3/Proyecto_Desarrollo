using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class prueba_lugar3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fk_lugar",
                table: "Lugares");

            migrationBuilder.AddColumn<int>(
                name: "LugarId_lugar",
                table: "Lugares",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lugares_LugarId_lugar",
                table: "Lugares",
                column: "LugarId_lugar");

            migrationBuilder.AddForeignKey(
                name: "FK_Lugares_Lugares_LugarId_lugar",
                table: "Lugares",
                column: "LugarId_lugar",
                principalTable: "Lugares",
                principalColumn: "Id_lugar",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lugares_Lugares_LugarId_lugar",
                table: "Lugares");

            migrationBuilder.DropIndex(
                name: "IX_Lugares_LugarId_lugar",
                table: "Lugares");

            migrationBuilder.DropColumn(
                name: "LugarId_lugar",
                table: "Lugares");

            migrationBuilder.AddColumn<int>(
                name: "fk_lugar",
                table: "Lugares",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
