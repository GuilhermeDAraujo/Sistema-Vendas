using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.ViewModels
{
    public class RelatorioVendasDataViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DataDe { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime DataAte { get; set; } = DateTime.Now;
        public List<Venda> ListaDeVendas { get; set; } = new List<Venda>(); //Armazena a lista de vendas que será retornada com base no filtro
    }
}