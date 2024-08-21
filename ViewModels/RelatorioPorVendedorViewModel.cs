using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.ViewModels
{
    public class RelatorioPorVendedorViewModel
    {
        public int ProcurarVendedorId {get;set;}
        public List<Venda> ListaDeVendas {get;set;}
    
    }
}