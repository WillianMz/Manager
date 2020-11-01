using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class AjusteNaClasseTicketEUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Status_StatusId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PrioridadeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PrioridadeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tickets");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelamento",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoCancelamento",
                table: "Tickets",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Tickets",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCancelamentoId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioFechamentoId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsuarioCancelamentoId",
                table: "Tickets",
                column: "UsuarioCancelamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsuarioFechamentoId",
                table: "Tickets",
                column: "UsuarioFechamentoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioCancelamentoId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioFechamentoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UsuarioCancelamentoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UsuarioFechamentoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DataCancelamento",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MotivoCancelamento",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UsuarioCancelamentoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UsuarioFechamentoId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "PrioridadeId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PrioridadeId",
                table: "Tickets",
                column: "PrioridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadeId",
                table: "Tickets",
                column: "PrioridadeId",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Status_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
