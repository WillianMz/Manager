using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class NovoVersaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 45, nullable: false),
                    URL = table.Column<string>(maxLength: 200, nullable: false),
                    teste = table.Column<string>(nullable: true),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    TipoUsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoUsuarios",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Gerente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoUsuarios", x => new { x.ProjetoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_ProjetoUsuarios_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    Descricao = table.Column<string>(maxLength: 300, nullable: false),
                    Versao = table.Column<string>(nullable: true),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    DataDeLiberacao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Releases_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Releases_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    DataFechamento = table.Column<DateTime>(nullable: true),
                    Tempo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 300, nullable: false),
                    Solucao = table.Column<string>(maxLength: 300, nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    PrioridadeId = table.Column<int>(nullable: true),
                    StatusAtual = table.Column<int>(nullable: false),
                    PrioridadeAtual = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Prioridades_PrioridadeId",
                        column: x => x.PrioridadeId,
                        principalTable: "Prioridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anexos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    URL = table.Column<string>(maxLength: 300, nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anexos_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 45, nullable: false),
                    Descricao = table.Column<string>(maxLength: 400, nullable: false),
                    DataDaNota = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prioridades",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Baixo" },
                    { 2, "Normal" },
                    { 3, "Alto" },
                    { 4, "Urgente" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Aberto" },
                    { 2, "EmAndamento" },
                    { 3, "Concluido" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "TipoUsuarios",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "MembroEquipe" },
                    { 4, "Cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_TicketId",
                table: "Anexos",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProjetoId",
                table: "Documentos",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_teste",
                table: "Documentos",
                column: "teste",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TicketId",
                table: "Notas",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoUsuarios_UsuarioId",
                table: "ProjetoUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ProjetoId",
                table: "Releases",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_UsuarioId",
                table: "Releases",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoriaId",
                table: "Tickets",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PrioridadeId",
                table: "Tickets",
                column: "PrioridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjetoId",
                table: "Tickets",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsuarioId",
                table: "Tickets",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "ProjetoUsuarios");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
