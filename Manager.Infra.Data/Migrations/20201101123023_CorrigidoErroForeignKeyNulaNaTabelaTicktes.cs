using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class CorrigidoErroForeignKeyNulaNaTabelaTicktes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioCancelamentoId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioFechamentoId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioFechamentoId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioCancelamentoId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioCancelamentoId",
                table: "Tickets",
                column: "UsuarioCancelamentoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioFechamentoId",
                table: "Tickets",
                column: "UsuarioFechamentoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioCancelamentoId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioFechamentoId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioFechamentoId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioCancelamentoId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioCancelamentoId",
                table: "Tickets",
                column: "UsuarioCancelamentoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioFechamentoId",
                table: "Tickets",
                column: "UsuarioFechamentoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
