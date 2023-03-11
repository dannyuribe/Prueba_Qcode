using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qcode.Datos.Migrations
{
    /// <inheritdoc />
    public partial class segundo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuarios_IdTipoUsuario",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios");
        }
    }
}
