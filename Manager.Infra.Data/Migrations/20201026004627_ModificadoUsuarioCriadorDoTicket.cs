using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class ModificadoUsuarioCriadorDoTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UsuarioId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "CriadorId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CriadorId",
                table: "Tickets",
                column: "CriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_CriadorId",
                table: "Tickets",
                column: "CriadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_CriadorId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CriadorId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsuarioId",
                table: "Tickets",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioId",
                table: "Tickets",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
