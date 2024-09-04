using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Projeto_Sistema_de_Vendas.Servicos
{
    public class RelatorioServices
    {
        private readonly SistemaVendaContext _context;

        public RelatorioServices(SistemaVendaContext context)
        {
            _context = context;
        }

        public async Task<Relatorio> ConsultaAsync(Relatorio relatorio)
        {
            if(relatorio != null)
            {
                relatorio.ListaDeVendas = await _context.Vendas
                    .Where(v => v.DataVenda >= relatorio.minData && v.DataVenda <= relatorio.maxData)
                    .Include(v => v.Vendedor)
                    .Include(c => c.Cliente)
                    .OrderByDescending(x => x.DataVenda)
                    .ToListAsync();
            }
            return relatorio;
        }

        public async Task<Relatorio> ConsultaVendedor(Relatorio relatorio)
        {
            if(relatorio != null)
            {
                relatorio.ListaDeVendas = await _context.Vendas
                    .Where(v => v.VendedorId == relatorio.ProcurarVendedorId)
                    .Include(v => v.Vendedor)
                    .Include(c => c.Cliente)
                    .OrderByDescending(v => v.DataVenda)
                    .ToListAsync();
            }
            return relatorio;
        }

        public async Task<List<Vendedor>> EncontrarTodosVendedoresAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }
    }
}