using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Sistema_de_Vendas.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoNomeDaListaJSONVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListaJSON",
                table: "Vendas",
                newName: "ListaProdutosJSON");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListaProdutosJSON",
                table: "Vendas",
                newName: "ListaJSON");
        }
    }
}
