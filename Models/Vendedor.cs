using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Vendedor
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "Informe o Nome do Vendedor!")]
        public string Nome {get;set;}

        [Required(ErrorMessage = "Informe o E-mail do Vendedor!")]
        public string Email {get;set;}
        public string Senha {get;set;}

        public List<Venda> Vendas {get;set;} = new List<Venda>();
    }
}