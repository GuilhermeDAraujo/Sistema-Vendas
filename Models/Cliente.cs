using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Cliente
    {
        public int Id {get;set;}
        
        [Required(ErrorMessage = "Informe o Nome do usúario!")]
        public string Nome {get;set;}

        [Required(ErrorMessage = "Informe o CPF/CNPJ do usúario!")]
        public string CpfCnpj {get;set;}

        [Required(ErrorMessage = "Informe o E-mail do usúario!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]        
        public string Email {get;set;}

        [Required(ErrorMessage = "Informe a senha do usúario!")]
        public string Senha {get;set;}

        public ICollection<Venda> Vendas {get;set;}
        
        
    }
}