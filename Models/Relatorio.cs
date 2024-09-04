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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime minData { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime maxData { get; set; }
        public int ProcurarVendedorId { get; set; }
        public List<Venda> ListaDeVendas { get; set; } = new List<Venda>(); //Armazena a lista de vendas que será retornada com base no filtro

        public decimal Total
        {
            get
            {
                return ListaDeVendas.Sum(v => v.Total);
            }
        }
    }
}