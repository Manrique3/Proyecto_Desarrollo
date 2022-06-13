using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class prueba_muchos4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaProveedor",
                columns: table => new
                {
                    MarcasIDMarca = table.Column<int>(type: "integer", nullable: false),
                    ProveedoresId_proveedor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaProveedor", x => new { x.MarcasIDMarca, x.ProveedoresId_proveedor });
                    table.ForeignKey(
                        name: "FK_MarcaProveedor_Marcas_MarcasIDMarca",
                        column: x => x.MarcasIDMarca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaProveedor_Proveedores_ProveedoresId_proveedor",
                        column: x => x.ProveedoresId_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvMarcas",
                columns: table => new
                {
                    IDMarca = table.Column<int>(type: "integer", nullable: false),
                    Id_proveedor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvMarcas", x => new { x.IDMarca, x.Id_proveedor });
                    table.ForeignKey(
                        name: "FK_ProvMarcas_Marcas_IDMarca",
                        column: x => x.IDMarca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvMarcas_Proveedores_Id_proveedor",
                        column: x => x.Id_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarcaProveedor_ProveedoresId_proveedor",
                table: "MarcaProveedor",
                column: "ProveedoresId_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ProvMarcas_Id_proveedor",
                table: "ProvMarcas",
                column: "Id_proveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaProveedor");

            migrationBuilder.DropTable(
                name: "ProvMarcas");
        }
    }
}
