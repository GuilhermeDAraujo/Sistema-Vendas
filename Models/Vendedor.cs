using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Vendedor
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}

        public ICollection<Venda> Vendas {get;set;}
    }
}