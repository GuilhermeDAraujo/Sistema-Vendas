using System.ComponentModel.DataAnnotations;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Vendedor
    {
        public int Id {get;set;}

        
        [Required(ErrorMessage = "{0} Informe o Nome do Vendedor!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage ="O Tamanho do {0} deve conter entre {2} e {1} caracteres!")] //1 = Maior e 2 = Menor
        public string Nome {get;set;}


        [Required(ErrorMessage = "{0} Obrigatório!")]
        [EmailAddress(ErrorMessage = "Informe um E-mail Válido!")]
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}

        [Required(ErrorMessage = "A {0} é Obrigatória!")]
        [StringLength(15, MinimumLength = 6, ErrorMessage ="O Tamanho do {0} deve conter entre {2} e {1} caracteres!")]  
        // [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).+$", ErrorMessage ="A {0} deve conter letra maiúscula e caractere especial!!")]
        public string Senha {get;set;} = "@Senha";

        public ICollection<Venda> Vendas {get;set;} = new List<Venda>();
    }
}