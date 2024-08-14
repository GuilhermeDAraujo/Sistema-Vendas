using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Venda
    {
        public int Id {get;set;}

        [DataType(DataType.Date)]
        public DateTime DataVenda {get;set;}
        public decimal Total {get;set;}

        public int VendedorId {get;set;}
        public Vendedor Vendedor {get;set;}

        public int ClienteId {get;set;}
        public Cliente Cliente {get;set;}

        public ICollection<VendaProduto> VendaProdutos {get;set;}

    }
}