using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_de_Vendas.Models
{
    public class Relatorio
    {
        [DataType(DataType.Date)]
        public DateTime DataDe {get;set;}

        [DataType(DataType.Date)]
        public DateTime DataAte {get;set;}

        public Vendedor Vendedor {get;set;}
        public int PesquisarVendedorId {get;set;}
        public List<Venda> ListaVendas {get;set;} = new List<Venda>(); //Armazena a lista de vendas que será retornada com base no filtro
    }
}