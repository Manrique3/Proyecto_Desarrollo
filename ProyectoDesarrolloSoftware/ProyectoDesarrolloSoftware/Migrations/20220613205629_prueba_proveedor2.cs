using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class prueba_proveedor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Lugares_Id_lugar",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Marcas_IDMarca",
                table: "Vehiculos");

            migrationBuilder.AlterColumn<int>(
                name: "IDMarca",
                table: "Vehiculos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "fk_marca",
                table: "Vehiculos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id_lugar",
                table: "Proveedores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "fk_lugar",
                table: "Proveedores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Lugares_Id_lugar",
                table: "Proveedores",
                column: "Id_lugar",
                principalTable: "Lugares",
                principalColumn: "Id_lugar",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Marcas_IDMarca",
                table: "Vehiculos",
                column: "IDMarca",
                principalTable: "Marcas",
                principalColumn: "IDMarca",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Lugares_Id_lugar",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Marcas_IDMarca",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "fk_marca",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "fk_lugar",
                table: "Proveedores");

            migrationBuilder.AlterColumn<int>(
                name: "IDMarca",
                table: "Vehiculos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_lugar",
                table: "Proveedores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Lugares_Id_lugar",
                table: "Proveedores",
                column: "Id_lugar",
                principalTable: "Lugares",
                principalColumn: "Id_lugar",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Marcas_IDMarca",
                table: "Vehiculos",
                column: "IDMarca",
                principalTable: "Marcas",
                principalColumn: "IDMarca",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
