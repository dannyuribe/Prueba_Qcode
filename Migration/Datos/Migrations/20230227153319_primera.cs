using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qcode.Datos.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
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
                name: "Vehiculos",
                columns: table => new
                {
                    SerialVehiculo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Marca = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<int>(type: "int", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Imagen = table.Column<byte[]>(type: "longblob", maxLength: 300000, nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(53,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.SerialVehiculo);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
