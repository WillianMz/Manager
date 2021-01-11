using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class CriadoClassesDeTipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDePrioridades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDePrioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeUsuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoDeStatus",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Aberto" },
                    { 2, "Em Andamento" },
                    { 3, "Concluído" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "TiposDePrioridades",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Baixo" },
                    { 2, "Normal" },
                    { 3, "Alto" },
                    { 4, "Urgente" }
                });

            migrationBuilder.InsertData(
                table: "TiposDeUsuarios",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "Membro de Equipe" },
                    { 4, "Cliente" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDeStatus");

            migrationBuilder.DropTable(
                name: "TiposDePrioridades");

            migrationBuilder.DropTable(
                name: "TiposDeUsuarios");
        }
    }
}
