using System.ComponentModel.DataAnnotations;


namespace Projeto_Sistema_de_Vendas.Models
{
    public class VendaProduto
    {
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }


        [Required]
        [Range(1, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal QuantidadeVendida { get; set; }

        

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal ValorProduto { get; set; }
    }
}