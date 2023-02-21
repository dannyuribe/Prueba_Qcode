using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Usuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoReparacion",
                columns: table => new
                {
                    IdEstadoReparacion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReparacion", x => x.IdEstadoReparacion);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    IdPropietario = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.IdPropietario);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    SerialVehiculo = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdPropietario = table.Column<string>(type: "varchar(255)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Marca = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.SerialVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Propietarios_IdPropietario",
                        column: x => x.IdPropietario,
                        principalTable: "Propietarios",
                        principalColumn: "IdPropietario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reparaciones",
                columns: table => new
                {
                    IdReparacion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaSale = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstadoReparacion = table.Column<long>(type: "bigint", nullable: false),
                    SerialVehiculo = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparaciones", x => x.IdReparacion);
                    table.ForeignKey(
                        name: "FK_Reparaciones_EstadoReparacion_IdEstadoReparacion",
                        column: x => x.IdEstadoReparacion,
                        principalTable: "EstadoReparacion",
                        principalColumn: "IdEstadoReparacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Vehiculos_SerialVehiculo",
                        column: x => x.SerialVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "SerialVehiculo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    IdDiagnostico = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdReparacion = table.Column<long>(type: "bigint", nullable: false),
                    IdEmpleado = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Resultados = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.IdDiagnostico);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Reparaciones_IdReparacion",
                        column: x => x.IdReparacion,
                        principalTable: "Reparaciones",
                        principalColumn: "IdReparacion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_IdEmpleado",
                table: "Diagnosticos",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_IdReparacion",
                table: "Diagnosticos",
                column: "IdReparacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdEstadoReparacion",
                table: "Reparaciones",
                column: "IdEstadoReparacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_SerialVehiculo",
                table: "Reparaciones",
                column: "SerialVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdPropietario",
                table: "Vehiculos",
                column: "IdPropietario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Reparaciones");

            migrationBuilder.DropTable(
                name: "EstadoReparacion");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
