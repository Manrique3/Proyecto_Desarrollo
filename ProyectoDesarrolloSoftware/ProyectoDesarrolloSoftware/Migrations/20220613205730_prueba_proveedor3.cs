using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class prueba_proveedor3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Marcas_IDMarca",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_IDMarca",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "IDMarca",
                table: "Vehiculos");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_fk_marca",
                table: "Vehiculos",
                column: "fk_marca");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Marcas_fk_marca",
                table: "Vehiculos",
                column: "fk_marca",
                principalTable: "Marcas",
                principalColumn: "IDMarca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Marcas_fk_marca",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_fk_marca",
                table: "Vehiculos");

            migrationBuilder.AddColumn<int>(
                name: "IDMarca",
                table: "Vehiculos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IDMarca",
                table: "Vehiculos",
                column: "IDMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Marcas_IDMarca",
                table: "Vehiculos",
                column: "IDMarca",
                principalTable: "Marcas",
                principalColumn: "IDMarca",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
