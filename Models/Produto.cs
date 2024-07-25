using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Produto
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Descricao {get;set;}
        public decimal PrecoUnitario {get;set;}
        public decimal QuantidadeEmEstoque {get;set;}
        public char UnidadeDeMedidaProduto {get;set;}
        public string Foto {get;set;}

        public ICollection<VendaProduto> VendaProdutos {get;set;}
    }
}