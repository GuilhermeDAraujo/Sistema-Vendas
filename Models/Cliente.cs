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
        
        [Required(ErrorMessage = "{0} Informe o Nome do Vendedor!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage ="O Tamanho do {0} deve conter entre {2} e {1} caracteres!")] //1 = Maior e 2 = Menor
        public string Nome {get;set;}

        [Required(ErrorMessage = "Informe o CPF ou CNPJ do usúario!")]
        [StringLength(14, MinimumLength = 11, ErrorMessage ="O CPF deve conter 11 dígitos e se for CNPJ 14 dígitos")]
        public string CpfCnpj {get;set;}

        [Required(ErrorMessage = "{0} Obrigatório!")]
        [EmailAddress(ErrorMessage = "Informe um E-mail Válido!")]
        [DataType(DataType.EmailAddress)]     
        public string Email {get;set;}

        // [Required(ErrorMessage = "A {0} é Obrigatória!")]
        // [StringLength(15, MinimumLength = 6, ErrorMessage ="O Tamanho do {0} deve conter entre {2} e {1} caracteres!")]  
        // [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).+$", ErrorMessage ="A {0} deve conter letra maiúscula e caractere especial!!")]
        public string Senha {get;set;}

        public ICollection<Venda> Vendas {get;set;} = new List<Venda>();
    }
}