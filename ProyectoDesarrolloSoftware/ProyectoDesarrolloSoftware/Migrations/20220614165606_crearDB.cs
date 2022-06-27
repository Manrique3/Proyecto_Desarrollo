using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class crearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lugares",
                columns: table => new
                {
                    Id_lugar = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_lugar = table.Column<string>(type: "text", nullable: false),
                    tipo_lugar = table.Column<string>(type: "text", nullable: false),
                    LugarId_lugar = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugares", x => x.Id_lugar);
                    table.ForeignKey(
                        name: "FK_Lugares_Lugares_LugarId_lugar",
                        column: x => x.LugarId_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IDMarca = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IDMarca);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDusuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDusuario);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id_proveedor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    fk_lugar = table.Column<int>(type: "integer", nullable: false),
                    Id_lugar = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id_proveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Lugares_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tallers",
                columns: table => new
                {
                    Id_Taller = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    fk_lugar = table.Column<int>(type: "integer", nullable: false),
                    Id_lugar = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallers", x => x.Id_Taller);
                    table.ForeignKey(
                        name: "FK_Tallers_Lugares_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IDVehiculo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Año = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    puestos = table.Column<int>(type: "integer", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    SerialMotor = table.Column<string>(type: "text", nullable: false),
                    fk_marca = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IDVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_fk_marca",
                        column: x => x.fk_marca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "MarcaTaller",
                columns: table => new
                {
                    MarcasIDMarca = table.Column<int>(type: "integer", nullable: false),
                    TallersId_Taller = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaTaller", x => new { x.MarcasIDMarca, x.TallersId_Taller });
                    table.ForeignKey(
                        name: "FK_MarcaTaller_Marcas_MarcasIDMarca",
                        column: x => x.MarcasIDMarca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaTaller_Tallers_TallersId_Taller",
                        column: x => x.TallersId_Taller,
                        principalTable: "Tallers",
                        principalColumn: "Id_Taller",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taller_Marca",
                columns: table => new
                {
                    IDMarca = table.Column<int>(type: "integer", nullable: false),
                    Id_Taller = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taller_Marca", x => new { x.IDMarca, x.Id_Taller });
                    table.ForeignKey(
                        name: "FK_Taller_Marca_Marcas_IDMarca",
                        column: x => x.IDMarca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taller_Marca_Tallers_Id_Taller",
                        column: x => x.Id_Taller,
                        principalTable: "Tallers",
                        principalColumn: "Id_Taller",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lugares_LugarId_lugar",
                table: "Lugares",
                column: "LugarId_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaProveedor_ProveedoresId_proveedor",
                table: "MarcaProveedor",
                column: "ProveedoresId_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaTaller_TallersId_Taller",
                table: "MarcaTaller",
                column: "TallersId_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_Id_lugar",
                table: "Proveedores",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_ProvMarcas_Id_proveedor",
                table: "ProvMarcas",
                column: "Id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Taller_Marca_Id_Taller",
                table: "Taller_Marca",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_Tallers_Id_lugar",
                table: "Tallers",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_fk_marca",
                table: "Vehiculos",
                column: "fk_marca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaProveedor");

            migrationBuilder.DropTable(
                name: "MarcaTaller");

            migrationBuilder.DropTable(
                name: "ProvMarcas");

            migrationBuilder.DropTable(
                name: "Taller_Marca");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Tallers");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Lugares");
        }
    }
}
