using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.ViewModels
{
    public class RelatorioVendedor
    {
        public int ProcurarVendedorId {get;set;}
        public List<Venda> ListaVendas {get;set;}
    }
}