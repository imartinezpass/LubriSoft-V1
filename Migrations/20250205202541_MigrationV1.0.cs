using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LubriSoft.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.telefono);
                });

            migrationBuilder.CreateTable(
                name: "fabricantes",
                columns: table => new
                {
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fabricantes", x => x.nombre);
                });

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.nombre);
                });

            migrationBuilder.CreateTable(
                name: "modelos",
                columns: table => new
                {
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fabricante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.nombre);
                    table.ForeignKey(
                        name: "FK_modelos_fabricantes_fabricante",
                        column: x => x.fabricante,
                        principalTable: "fabricantes",
                        principalColumn: "nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "aceites",
                columns: table => new
                {
                    nombreCompleto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    norma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aceites", x => x.nombreCompleto);
                    table.ForeignKey(
                        name: "FK_aceites_marcas_marca",
                        column: x => x.marca,
                        principalTable: "marcas",
                        principalColumn: "nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    patente = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    capacidadMotor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    capacidadCaja = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    fabricante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    clienteId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.patente);
                    table.ForeignKey(
                        name: "FK_vehiculos_clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "clientes",
                        principalColumn: "telefono",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehiculos_fabricantes_fabricante",
                        column: x => x.fabricante,
                        principalTable: "fabricantes",
                        principalColumn: "nombre",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehiculos_modelos_modelo",
                        column: x => x.modelo,
                        principalTable: "modelos",
                        principalColumn: "nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mecanica",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kmActual = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    detalle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    patente = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mecanica", x => x.id);
                    table.ForeignKey(
                        name: "FK_mecanica_vehiculos_patente",
                        column: x => x.patente,
                        principalTable: "vehiculos",
                        principalColumn: "patente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kmActual = table.Column<int>(type: "int", nullable: false),
                    kmProximo = table.Column<int>(type: "int", nullable: false),
                    filtroAire = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    filtroAceite = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    filtroCombustible = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    filtroHabitaculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    patente = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    aceite = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.id);
                    table.ForeignKey(
                        name: "FK_service_aceites_aceite",
                        column: x => x.aceite,
                        principalTable: "aceites",
                        principalColumn: "nombreCompleto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_service_vehiculos_patente",
                        column: x => x.patente,
                        principalTable: "vehiculos",
                        principalColumn: "patente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aceites_marca",
                table: "aceites",
                column: "marca");

            migrationBuilder.CreateIndex(
                name: "IX_mecanica_patente",
                table: "mecanica",
                column: "patente");

            migrationBuilder.CreateIndex(
                name: "IX_modelos_fabricante",
                table: "modelos",
                column: "fabricante");

            migrationBuilder.CreateIndex(
                name: "IX_service_aceite",
                table: "service",
                column: "aceite");

            migrationBuilder.CreateIndex(
                name: "IX_service_patente",
                table: "service",
                column: "patente");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_clienteId",
                table: "vehiculos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_fabricante",
                table: "vehiculos",
                column: "fabricante");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_modelo",
                table: "vehiculos",
                column: "modelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mecanica");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "aceites");

            migrationBuilder.DropTable(
                name: "vehiculos");

            migrationBuilder.DropTable(
                name: "marcas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "modelos");

            migrationBuilder.DropTable(
                name: "fabricantes");
        }
    }
}
