using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class Cambios_Finales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradors",
                columns: table => new
                {
                    Id_Administrador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradors", x => x.Id_Administrador);
                });

            migrationBuilder.CreateTable(
                name: "Asegurados",
                columns: table => new
                {
                    Cedula = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asegurados", x => x.Cedula);
                });

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
                name: "Peritos",
                columns: table => new
                {
                    Id_Perito = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peritos", x => x.Id_Perito);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.Id_Pieza);
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
                    fk_lugar = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id_proveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Lugares_fk_lugar",
                        column: x => x.fk_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tallers",
                columns: table => new
                {
                    Id_Taller = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    fk_lugar = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallers", x => x.Id_Taller);
                    table.ForeignKey(
                        name: "FK_Tallers_Lugares_fk_lugar",
                        column: x => x.fk_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Placa = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Año = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    puestos = table.Column<int>(type: "integer", nullable: false),
                    SerialMotor = table.Column<string>(type: "text", nullable: false),
                    fk_marca = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Placa);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_fk_marca",
                        column: x => x.fk_marca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pieza_Proveedor",
                columns: table => new
                {
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false),
                    Id_proveedor = table.Column<int>(type: "integer", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Pieza_Proveedor_Proveedores_Id_proveedor",
                        column: x => x.Id_proveedor,
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
                name: "Taller_Marcas",
                columns: table => new
                {
                    IDMarca = table.Column<int>(type: "integer", nullable: false),
                    Id_Taller = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taller_Marcas", x => new { x.IDMarca, x.Id_Taller });
                    table.ForeignKey(
                        name: "FK_Taller_Marcas_Marcas_IDMarca",
                        column: x => x.IDMarca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taller_Marcas_Tallers_Id_Taller",
                        column: x => x.Id_Taller,
                        principalTable: "Tallers",
                        principalColumn: "Id_Taller",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    Id_Poliza = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    fk_vehiculo = table.Column<int>(type: "integer", nullable: false),
                    AseguradoCedula = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.Id_Poliza);
                    table.ForeignKey(
                        name: "FK_Polizas_Asegurados_AseguradoCedula",
                        column: x => x.AseguradoCedula,
                        principalTable: "Asegurados",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Polizas_Vehiculos_fk_vehiculo",
                        column: x => x.fk_vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id_Incidente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estadoEv = table.Column<string>(type: "text", nullable: true),
                    fk_vehiculo_tercero = table.Column<int>(type: "integer", nullable: true),
                    fk_Poliza = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id_Incidente);
                    table.ForeignKey(
                        name: "FK_Incidentes_Polizas_fk_Poliza",
                        column: x => x.fk_Poliza,
                        principalTable: "Polizas",
                        principalColumn: "Id_Poliza",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidentes_Vehiculos_fk_vehiculo_tercero",
                        column: x => x.fk_vehiculo_tercero,
                        principalTable: "Vehiculos",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacions",
                columns: table => new
                {
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_incidente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacions", x => x.Id_Cotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizacions_Incidentes_fk_incidente",
                        column: x => x.fk_incidente,
                        principalTable: "Incidentes",
                        principalColumn: "Id_Incidente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidente_Pieza",
                columns: table => new
                {
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false),
                    Id_Incidente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidente_Pieza", x => new { x.Id_Pieza, x.Id_Incidente });
                    table.ForeignKey(
                        name: "FK_Incidente_Pieza_Incidentes_Id_Incidente",
                        column: x => x.Id_Incidente,
                        principalTable: "Incidentes",
                        principalColumn: "Id_Incidente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Pieza_Piezas_Id_Pieza",
                        column: x => x.Id_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id_Pieza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrador_Cotizacion",
                columns: table => new
                {
                    Id_Administrador = table.Column<int>(type: "integer", nullable: false),
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador_Cotizacion", x => new { x.Id_Administrador, x.Id_Cotizacion });
                    table.ForeignKey(
                        name: "FK_Administrador_Cotizacion_Administradors_Id_Administrador",
                        column: x => x.Id_Administrador,
                        principalTable: "Administradors",
                        principalColumn: "Id_Administrador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrador_Cotizacion_Cotizacions_Id_Cotizacion",
                        column: x => x.Id_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion_Proveedor",
                columns: table => new
                {
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false),
                    Id_Proveedor = table.Column<int>(type: "integer", nullable: false),
                    estatus = table.Column<string>(type: "text", nullable: true),
                    Id_Pieza_Pieza_Proveedor = table.Column<int>(type: "integer", nullable: false),
                    Id_Proveedor_Pieza_Proveedor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion_Proveedor", x => new { x.Id_Cotizacion, x.Id_Proveedor });
                    table.ForeignKey(
                        name: "FK_Cotizacion_Proveedor_Cotizacions_Id_Cotizacion",
                        column: x => x.Id_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Proveedor_Pieza_Proveedor_Id_Pieza_Pieza_Proveed~",
                        columns: x => new { x.Id_Pieza_Pieza_Proveedor, x.Id_Proveedor_Pieza_Proveedor },
                        principalTable: "Pieza_Proveedor",
                        principalColumns: new[] { "Id_Pieza", "Id_proveedor" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Proveedor_Proveedores_Id_Proveedor",
                        column: x => x.Id_Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion_Taller",
                columns: table => new
                {
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false),
                    Id_Taller = table.Column<int>(type: "integer", nullable: false),
                    estatus = table.Column<string>(type: "text", nullable: true),
                    cantidad_piezas_reparar = table.Column<int>(type: "integer", nullable: false),
                    costo_reparacion = table.Column<double>(type: "double precision", nullable: false),
                    tiempo_reparacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion_Taller", x => new { x.Id_Cotizacion, x.Id_Taller });
                    table.ForeignKey(
                        name: "FK_Cotizacion_Taller_Cotizacions_Id_Cotizacion",
                        column: x => x.Id_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Taller_Tallers_Id_Taller",
                        column: x => x.Id_Taller,
                        principalTable: "Tallers",
                        principalColumn: "Id_Taller",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estatus = table.Column<string>(type: "text", nullable: true),
                    pago_total = table.Column<double>(type: "double precision", nullable: false),
                    numero_factura = table.Column<int>(type: "integer", nullable: false),
                    fk_proveedor_prov_cot = table.Column<int>(type: "integer", nullable: true),
                    fk_cotizacion_prov_cot = table.Column<int>(type: "integer", nullable: true),
                    fk_taller_taller_cot = table.Column<int>(type: "integer", nullable: true),
                    fk_cotizacion_taller_cot = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cotizacion_Proveedor_fk_proveedor_prov_cot_fk_cotiz~",
                        columns: x => new { x.fk_proveedor_prov_cot, x.fk_cotizacion_prov_cot },
                        principalTable: "Cotizacion_Proveedor",
                        principalColumns: new[] { "Id_Cotizacion", "Id_Proveedor" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cotizacion_Taller_fk_taller_taller_cot_fk_cotizacio~",
                        columns: x => new { x.fk_taller_taller_cot, x.fk_cotizacion_taller_cot },
                        principalTable: "Cotizacion_Taller",
                        principalColumns: new[] { "Id_Cotizacion", "Id_Taller" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_Cotizacion_Id_Cotizacion",
                table: "Administrador_Cotizacion",
                column: "Id_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_Proveedor_Id_Pieza_Pieza_Proveedor_Id_Proveedor_~",
                table: "Cotizacion_Proveedor",
                columns: new[] { "Id_Pieza_Pieza_Proveedor", "Id_Proveedor_Pieza_Proveedor" });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_Proveedor_Id_Proveedor",
                table: "Cotizacion_Proveedor",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_Taller_Id_Taller",
                table: "Cotizacion_Taller",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacions_fk_incidente",
                table: "Cotizacions",
                column: "fk_incidente");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_Pieza_Id_Incidente",
                table: "Incidente_Pieza",
                column: "Id_Incidente");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_fk_Poliza",
                table: "Incidentes",
                column: "fk_Poliza");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_fk_vehiculo_tercero",
                table: "Incidentes",
                column: "fk_vehiculo_tercero");

            migrationBuilder.CreateIndex(
                name: "IX_Lugares_LugarId_lugar",
                table: "Lugares",
                column: "LugarId_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_fk_proveedor_prov_cot_fk_cotizacion_prov_cot",
                table: "Pedidos",
                columns: new[] { "fk_proveedor_prov_cot", "fk_cotizacion_prov_cot" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_fk_taller_taller_cot_fk_cotizacion_taller_cot",
                table: "Pedidos",
                columns: new[] { "fk_taller_taller_cot", "fk_cotizacion_taller_cot" });

            migrationBuilder.CreateIndex(
                name: "IX_Pieza_Proveedor_Id_proveedor",
                table: "Pieza_Proveedor",
                column: "Id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_AseguradoCedula",
                table: "Polizas",
                column: "AseguradoCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_fk_vehiculo",
                table: "Polizas",
                column: "fk_vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_fk_lugar",
                table: "Proveedores",
                column: "fk_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_ProvMarcas_Id_proveedor",
                table: "ProvMarcas",
                column: "Id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Taller_Marcas_Id_Taller",
                table: "Taller_Marcas",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_Tallers_fk_lugar",
                table: "Tallers",
                column: "fk_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_fk_marca",
                table: "Vehiculos",
                column: "fk_marca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador_Cotizacion");

            migrationBuilder.DropTable(
                name: "Incidente_Pieza");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Peritos");

            migrationBuilder.DropTable(
                name: "ProvMarcas");

            migrationBuilder.DropTable(
                name: "Taller_Marcas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "Cotizacion_Proveedor");

            migrationBuilder.DropTable(
                name: "Cotizacion_Taller");

            migrationBuilder.DropTable(
                name: "Pieza_Proveedor");

            migrationBuilder.DropTable(
                name: "Cotizacions");

            migrationBuilder.DropTable(
                name: "Tallers");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Lugares");

            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Asegurados");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
