using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque.Data.Migrations
{
    /// <inheritdoc />
    public partial class maisuma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_categoriaidCategoria",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_categoriaidCategoria",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "categoriaidCategoria",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "categoriaprodutos",
                columns: table => new
                {
                    categoriaidCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    produtosidProdutos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaprodutos", x => new { x.categoriaidCategoria, x.produtosidProdutos });
                    table.ForeignKey(
                        name: "FK_categoriaprodutos_Categoria_categoriaidCategoria",
                        column: x => x.categoriaidCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriaprodutos_Produto_produtosidProdutos",
                        column: x => x.produtosidProdutos,
                        principalTable: "Produto",
                        principalColumn: "idProdutos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoriaprodutos_produtosidProdutos",
                table: "categoriaprodutos",
                column: "produtosidProdutos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriaprodutos");

            migrationBuilder.AddColumn<int>(
                name: "categoriaidCategoria",
                table: "Produto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_categoriaidCategoria",
                table: "Produto",
                column: "categoriaidCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_categoriaidCategoria",
                table: "Produto",
                column: "categoriaidCategoria",
                principalTable: "Categoria",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
