using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque.Data.Migrations
{
    /// <inheritdoc />
    public partial class adiconandoEstoqueInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "valorVenda",
                table: "Produto",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Produto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produto");

            migrationBuilder.AlterColumn<decimal>(
                name: "valorVenda",
                table: "Produto",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
