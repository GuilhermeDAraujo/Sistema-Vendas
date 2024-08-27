using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Produto
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "Informe o Nome do Produto!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage ="O Tamanho do {0} deve conter entre {2} e {1} caracteres!")] //1 = Maior e 2 = Menor
        public string Nome {get;set;}


        [Required(ErrorMessage = "Informe a Descrição!")]
        [StringLength(50, ErrorMessage ="O Tamanho do {0} deve conter no maxímo {1} caracteres!")]
        public string Descricao {get;set;}


        [Required(ErrorMessage = "Informe o Valor Unitário!")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor Não Pode Ser Negativa")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage ="Utilize o ponto como separador decimal")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? PrecoUnitario {get;set;}


        [Required(ErrorMessage = "Informe a Quantidade!")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantidade Não Pode Ser Negativa")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage ="Utilize o ponto como separador decimal")]
        public decimal? QuantidadeEmEstoque {get;set;}


        [Required(ErrorMessage = "Informe a Unidade de Medida!")]
        public string UnidadeDeMedidaProduto {get;set;}


        [Required(ErrorMessage = "Informe o Link da Foto")]
        public string Foto {get;set;}

        public ICollection<VendaProduto> VendaProdutos {get;set;} = new List<VendaProduto>();
        

        public static IEnumerable<SelectListItem> GetUnidadeDeMedidaOpcoes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem  {Value = "", Text = "Selecione..."},
                new SelectListItem  {Value = "UN", Text = "Unidade"},
                new SelectListItem  {Value = "KG", Text = "KG"},
                new SelectListItem  {Value = "GR", Text = "GR"},
                new SelectListItem  {Value = "LT", Text = "Litro"},
                new SelectListItem  {Value = "CX", Text = "Caixa"}
            };
        }
    }
}