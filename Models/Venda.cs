using System.ComponentModel.DataAnnotations;


namespace Projeto_Sistema_de_Vendas.Models
{
    public class Venda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Data da realização da Venda!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVenda { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Total { get; set; }

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<VendaProduto> VendaProdutos { get; set; } = new List<VendaProduto>();
        

        [Required(ErrorMessage = "É necessário adicionar um produto a venda!")]
        public string ListaProdutosJSON { get; set; }
    }
}