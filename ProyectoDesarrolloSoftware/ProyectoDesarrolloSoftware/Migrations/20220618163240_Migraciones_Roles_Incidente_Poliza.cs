using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class Migraciones_Roles_Incidente_Poliza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taller_Marca_Marcas_IDMarca",
                table: "Taller_Marca");

            migrationBuilder.DropForeignKey(
                name: "FK_Taller_Marca_Tallers_Id_Taller",
                table: "Taller_Marca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taller_Marca",
                table: "Taller_Marca");

            migrationBuilder.RenameTable(
                name: "Taller_Marca",
                newName: "Taller_Marcas");

            migrationBuilder.RenameIndex(
                name: "IX_Taller_Marca_Id_Taller",
                table: "Taller_Marcas",
                newName: "IX_Taller_Marcas_Id_Taller");

            migrationBuilder.AddColumn<int>(
                name: "CotizacionId_Cotizacion",
                table: "Tallers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CotizacionId_Cotizacion",
                table: "Piezas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolizaId_Poliza",
                table: "Asegurados",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taller_Marcas",
                table: "Taller_Marcas",
                columns: new[] { "IDMarca", "Id_Taller" });

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
                name: "Poliza",
                columns: table => new
                {
                    Id_Poliza = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehiculoIDVehiculo = table.Column<int>(type: "integer", nullable: true),
                    AdministradorId_Administrador = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Nombre_tercero = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliza", x => x.Id_Poliza);
                    table.ForeignKey(
                        name: "FK_Poliza_Administradors_AdministradorId_Administrador",
                        column: x => x.AdministradorId_Administrador,
                        principalTable: "Administradors",
                        principalColumn: "Id_Administrador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poliza_Vehiculos_VehiculoIDVehiculo",
                        column: x => x.VehiculoIDVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "IDVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id_Incidente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeritoId_Perito = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id_Incidente);
                    table.ForeignKey(
                        name: "FK_Incidentes_Peritos_PeritoId_Perito",
                        column: x => x.PeritoId_Perito,
                        principalTable: "Peritos",
                        principalColumn: "Id_Perito",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacions",
                columns: table => new
                {
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncidenteId_Incidente = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacions", x => x.Id_Cotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizacions_Incidentes_IncidenteId_Incidente",
                        column: x => x.IncidenteId_Incidente,
                        principalTable: "Incidentes",
                        principalColumn: "Id_Incidente",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AdministradorCotizacion",
                columns: table => new
                {
                    AdministradorsId_Administrador = table.Column<int>(type: "integer", nullable: false),
                    CotizacionsId_Cotizacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradorCotizacion", x => new { x.AdministradorsId_Administrador, x.CotizacionsId_Cotizacion });
                    table.ForeignKey(
                        name: "FK_AdministradorCotizacion_Administradors_AdministradorsId_Adm~",
                        column: x => x.AdministradorsId_Administrador,
                        principalTable: "Administradors",
                        principalColumn: "Id_Administrador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministradorCotizacion_Cotizacions_CotizacionsId_Cotizacion",
                        column: x => x.CotizacionsId_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion__Pieza",
                columns: table => new
                {
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false),
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion__Pieza", x => new { x.Id_Cotizacion, x.Id_Pieza });
                    table.ForeignKey(
                        name: "FK_Cotizacion__Pieza_Cotizacions_Id_Cotizacion",
                        column: x => x.Id_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizacion__Pieza_Piezas_Id_Pieza",
                        column: x => x.Id_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "Id_Pieza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion_Proveedor",
                columns: table => new
                {
                    Id_Cotizacion = table.Column<int>(type: "integer", nullable: false),
                    Id_Proveedor = table.Column<int>(type: "integer", nullable: false)
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
                    Id_Taller = table.Column<int>(type: "integer", nullable: false)
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
                name: "CotizacionProveedor",
                columns: table => new
                {
                    CotizacionsId_Cotizacion = table.Column<int>(type: "integer", nullable: false),
                    ProveedorsId_proveedor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionProveedor", x => new { x.CotizacionsId_Cotizacion, x.ProveedorsId_proveedor });
                    table.ForeignKey(
                        name: "FK_CotizacionProveedor_Cotizacions_CotizacionsId_Cotizacion",
                        column: x => x.CotizacionsId_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionProveedor_Proveedores_ProveedorsId_proveedor",
                        column: x => x.ProveedorsId_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tallers_CotizacionId_Cotizacion",
                table: "Tallers",
                column: "CotizacionId_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_CotizacionId_Cotizacion",
                table: "Piezas",
                column: "CotizacionId_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Asegurados_PolizaId_Poliza",
                table: "Asegurados",
                column: "PolizaId_Poliza");

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_Cotizacion_Id_Cotizacion",
                table: "Administrador_Cotizacion",
                column: "Id_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorCotizacion_CotizacionsId_Cotizacion",
                table: "AdministradorCotizacion",
                column: "CotizacionsId_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion__Pieza_Id_Pieza",
                table: "Cotizacion__Pieza",
                column: "Id_Pieza");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_Proveedor_Id_Proveedor",
                table: "Cotizacion_Proveedor",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_Taller_Id_Taller",
                table: "Cotizacion_Taller",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProveedor_ProveedorsId_proveedor",
                table: "CotizacionProveedor",
                column: "ProveedorsId_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacions_IncidenteId_Incidente",
                table: "Cotizacions",
                column: "IncidenteId_Incidente");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_PeritoId_Perito",
                table: "Incidentes",
                column: "PeritoId_Perito");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_AdministradorId_Administrador",
                table: "Poliza",
                column: "AdministradorId_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_VehiculoIDVehiculo",
                table: "Poliza",
                column: "VehiculoIDVehiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Asegurados_Poliza_PolizaId_Poliza",
                table: "Asegurados",
                column: "PolizaId_Poliza",
                principalTable: "Poliza",
                principalColumn: "Id_Poliza",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piezas_Cotizacions_CotizacionId_Cotizacion",
                table: "Piezas",
                column: "CotizacionId_Cotizacion",
                principalTable: "Cotizacions",
                principalColumn: "Id_Cotizacion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Taller_Marcas_Marcas_IDMarca",
                table: "Taller_Marcas",
                column: "IDMarca",
                principalTable: "Marcas",
                principalColumn: "IDMarca",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taller_Marcas_Tallers_Id_Taller",
                table: "Taller_Marcas",
                column: "Id_Taller",
                principalTable: "Tallers",
                principalColumn: "Id_Taller",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tallers_Cotizacions_CotizacionId_Cotizacion",
                table: "Tallers",
                column: "CotizacionId_Cotizacion",
                principalTable: "Cotizacions",
                principalColumn: "Id_Cotizacion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asegurados_Poliza_PolizaId_Poliza",
                table: "Asegurados");

            migrationBuilder.DropForeignKey(
                name: "FK_Piezas_Cotizacions_CotizacionId_Cotizacion",
                table: "Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Taller_Marcas_Marcas_IDMarca",
                table: "Taller_Marcas");

            migrationBuilder.DropForeignKey(
                name: "FK_Taller_Marcas_Tallers_Id_Taller",
                table: "Taller_Marcas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tallers_Cotizacions_CotizacionId_Cotizacion",
                table: "Tallers");

            migrationBuilder.DropTable(
                name: "Administrador_Cotizacion");

            migrationBuilder.DropTable(
                name: "AdministradorCotizacion");

            migrationBuilder.DropTable(
                name: "Cotizacion__Pieza");

            migrationBuilder.DropTable(
                name: "Cotizacion_Proveedor");

            migrationBuilder.DropTable(
                name: "Cotizacion_Taller");

            migrationBuilder.DropTable(
                name: "CotizacionProveedor");

            migrationBuilder.DropTable(
                name: "Poliza");

            migrationBuilder.DropTable(
                name: "Cotizacions");

            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Peritos");

            migrationBuilder.DropIndex(
                name: "IX_Tallers_CotizacionId_Cotizacion",
                table: "Tallers");

            migrationBuilder.DropIndex(
                name: "IX_Piezas_CotizacionId_Cotizacion",
                table: "Piezas");

            migrationBuilder.DropIndex(
                name: "IX_Asegurados_PolizaId_Poliza",
                table: "Asegurados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taller_Marcas",
                table: "Taller_Marcas");

            migrationBuilder.DropColumn(
                name: "CotizacionId_Cotizacion",
                table: "Tallers");

            migrationBuilder.DropColumn(
                name: "CotizacionId_Cotizacion",
                table: "Piezas");

            migrationBuilder.DropColumn(
                name: "PolizaId_Poliza",
                table: "Asegurados");

            migrationBuilder.RenameTable(
                name: "Taller_Marcas",
                newName: "Taller_Marca");

            migrationBuilder.RenameIndex(
                name: "IX_Taller_Marcas_Id_Taller",
                table: "Taller_Marca",
                newName: "IX_Taller_Marca_Id_Taller");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taller_Marca",
                table: "Taller_Marca",
                columns: new[] { "IDMarca", "Id_Taller" });

            migrationBuilder.AddForeignKey(
                name: "FK_Taller_Marca_Marcas_IDMarca",
                table: "Taller_Marca",
                column: "IDMarca",
                principalTable: "Marcas",
                principalColumn: "IDMarca",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taller_Marca_Tallers_Id_Taller",
                table: "Taller_Marca",
                column: "Id_Taller",
                principalTable: "Tallers",
                principalColumn: "Id_Taller",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
