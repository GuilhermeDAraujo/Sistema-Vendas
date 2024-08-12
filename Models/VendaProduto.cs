using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class VendaProduto
    {
        public int VendaId {get;set;}
        public Venda Venda {get;set;}

        public int ProdutoId {get;set;}
        public Produto Produto {get;set;}
        public decimal QuantidadeVendida {get;set;}
        public decimal ValorProduto {get;set;}
    }
}