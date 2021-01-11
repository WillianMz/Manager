using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Data.Migrations
{
    public partial class CorrigidoTamanhoCampoDescricaoTabelasTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TiposDeUsuarios",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10) CHARACTER SET utf8mb4",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TiposDePrioridades",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10) CHARACTER SET utf8mb4",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoDeStatus",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10) CHARACTER SET utf8mb4",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TiposDeUsuarios",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TiposDePrioridades",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoDeStatus",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);
        }
    }
}
