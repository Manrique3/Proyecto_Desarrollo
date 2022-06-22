using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class PiezaProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.Id_Pieza);
                });

            migrationBuilder.CreateTable(
                name: "Pieza_Proveedor",
                columns: table => new
                {
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false),
                    Id_proveedor = table.Column<int>(type: "integer", nullable: false),
                    Id_Proveedor = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieza_Proveedor", x => new { x.Id_Pieza, x.Id_proveedor });
                    table.ForeignKey(
                        name: "FK_Pieza_Proveedor_Piezas_Id_Pieza",
                        column: x => x.Id_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id_Pieza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pieza_Proveedor_Proveedores_Id_Proveedor",
                        column: x => x.Id_Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PiezaProveedor",
                columns: table => new
                {
                    PiezasId_Pieza = table.Column<int>(type: "integer", nullable: false),
                    ProveedorsId_proveedor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiezaProveedor", x => new { x.PiezasId_Pieza, x.ProveedorsId_proveedor });
                    table.ForeignKey(
                        name: "FK_PiezaProveedor_Piezas_PiezasId_Pieza",
                        column: x => x.PiezasId_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id_Pieza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiezaProveedor_Proveedores_ProveedorsId_proveedor",
                        column: x => x.ProveedorsId_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pieza_Proveedor_Id_Proveedor",
                table: "Pieza_Proveedor",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaProveedor_ProveedorsId_proveedor",
                table: "PiezaProveedor",
                column: "ProveedorsId_proveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pieza_Proveedor");

            migrationBuilder.DropTable(
                name: "PiezaProveedor");

            migrationBuilder.DropTable(
                name: "Piezas");
        }
    }
}
