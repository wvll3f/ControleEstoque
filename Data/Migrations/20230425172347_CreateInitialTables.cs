using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeCategoria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    idProdutos = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeProduto = table.Column<string>(type: "TEXT", nullable: false),
                    valorProduto = table.Column<decimal>(type: "TEXT", nullable: false),
                    valorCompra = table.Column<decimal>(type: "TEXT", nullable: false),
                    valorVenda = table.Column<decimal>(type: "TEXT", nullable: false),
                    dataProduto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    categoriaidCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.idProdutos);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_categoriaidCategoria",
                        column: x => x.categoriaidCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_categoriaidCategoria",
                table: "Produto",
                column: "categoriaidCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
