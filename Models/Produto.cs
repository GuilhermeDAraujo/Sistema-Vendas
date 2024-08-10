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
        public string Nome {get;set;}


        [Required(ErrorMessage = "Informe a Descrição!")]
        public string Descricao {get;set;}


        [Required(ErrorMessage = "Informe o Valor Unitário!")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor Não Pode Ser Negativo!")]
        public decimal? PrecoUnitario {get;set;}


        [Required(ErrorMessage = "Informe a Quantidade!")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantidade Não Pode Ser Negativa")]
        public decimal? QuantidadeEmEstoque {get;set;}


        [Required(ErrorMessage = "Informe a Unidade de Medida!")]
        public string UnidadeDeMedidaProduto {get;set;}


        [Required(ErrorMessage = "Informe o Link da Foto")]
        public string Foto {get;set;}

        public ICollection<VendaProduto> VendaProdutos {get;set;}
        

        public static IEnumerable<SelectListItem> GetUnidadeDeMedidaOpcoes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem  {Value = "", Text = "Selecione..."},
                new SelectListItem  {Value = "U", Text = "Unidade"},
                new SelectListItem  {Value = "K", Text = "KG"},
                new SelectListItem  {Value = "G", Text = "GR"},
                new SelectListItem  {Value = "L", Text = "Litro"},
                new SelectListItem  {Value = "C", Text = "Caixa"}
            };
        }
    }
}