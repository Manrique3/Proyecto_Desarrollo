using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProyectoDesarrolloSoftware.Migrations
{
    public partial class corrigiendo_errores : Migration
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
                name: "Asegurados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    PolizaId_Poliza = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asegurados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asegurados_Poliza_PolizaId_Poliza",
                        column: x => x.PolizaId_Poliza,
                        principalTable: "Poliza",
                        principalColumn: "Id_Poliza",
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

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    Id_Pieza = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<int>(type: "integer", nullable: false),
                    CotizacionId_Cotizacion = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.Id_Pieza);
                    table.ForeignKey(
                        name: "FK_Piezas_Cotizacions_CotizacionId_Cotizacion",
                        column: x => x.CotizacionId_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
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
                    Id_lugar = table.Column<int>(type: "integer", nullable: true),
                    CotizacionId_Cotizacion = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallers", x => x.Id_Taller);
                    table.ForeignKey(
                        name: "FK_Tallers_Cotizacions_CotizacionId_Cotizacion",
                        column: x => x.CotizacionId_Cotizacion,
                        principalTable: "Cotizacions",
                        principalColumn: "Id_Cotizacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tallers_Lugares_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_Cotizacion_Id_Cotizacion",
                table: "Administrador_Cotizacion",
                column: "Id_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorCotizacion_CotizacionsId_Cotizacion",
                table: "AdministradorCotizacion",
                column: "CotizacionsId_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Asegurados_PolizaId_Poliza",
                table: "Asegurados",
                column: "PolizaId_Poliza");

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
                name: "IX_Pieza_Proveedor_Id_Proveedor",
                table: "Pieza_Proveedor",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaProveedor_ProveedorsId_proveedor",
                table: "PiezaProveedor",
                column: "ProveedorsId_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_CotizacionId_Cotizacion",
                table: "Piezas",
                column: "CotizacionId_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_AdministradorId_Administrador",
                table: "Poliza",
                column: "AdministradorId_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_VehiculoIDVehiculo",
                table: "Poliza",
                column: "VehiculoIDVehiculo");

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
                name: "IX_Tallers_CotizacionId_Cotizacion",
                table: "Tallers",
                column: "CotizacionId_Cotizacion");

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
                name: "Administrador_Cotizacion");

            migrationBuilder.DropTable(
                name: "AdministradorCotizacion");

            migrationBuilder.DropTable(
                name: "Asegurados");

            migrationBuilder.DropTable(
                name: "Cotizacion__Pieza");

            migrationBuilder.DropTable(
                name: "Cotizacion_Proveedor");

            migrationBuilder.DropTable(
                name: "Cotizacion_Taller");

            migrationBuilder.DropTable(
                name: "CotizacionProveedor");

            migrationBuilder.DropTable(
                name: "MarcaProveedor");

            migrationBuilder.DropTable(
                name: "MarcaTaller");

            migrationBuilder.DropTable(
                name: "Pieza_Proveedor");

            migrationBuilder.DropTable(
                name: "PiezaProveedor");

            migrationBuilder.DropTable(
                name: "ProvMarcas");

            migrationBuilder.DropTable(
                name: "Taller_Marcas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Poliza");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Tallers");

            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Cotizacions");

            migrationBuilder.DropTable(
                name: "Lugares");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Peritos");
        }
    }
}
