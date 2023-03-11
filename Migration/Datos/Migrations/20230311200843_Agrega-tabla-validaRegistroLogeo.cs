using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qcode.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AgregatablavalidaRegistroLogeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuarios_IdTipoUsuario",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "ActivarUsuarioLogeos",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Logeo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CodigoActivacion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivarUsuarioLogeos", x => x.IdUsuario);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivarUsuarioLogeos");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario",
                principalTable: "TipoUsuarios",
                principalColumn: "IdTipoUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
