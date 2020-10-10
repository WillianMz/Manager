using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class AlteradoEstruturaDeClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documentos_teste",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "teste",
                table: "Documentos");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Releases_Nome",
                table: "Releases",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Nome",
                table: "Categorias",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Releases_Nome",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_Nome",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "teste",
                table: "Documentos",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_teste",
                table: "Documentos",
                column: "teste",
                unique: true);
        }
    }
}
