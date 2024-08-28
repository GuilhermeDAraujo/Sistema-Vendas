using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Servicos
{
    public class VendedorServicos
    {
        private readonly SistemaVendaContext _context;

        public VendedorServicos(SistemaVendaContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> EncontrarTodosAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }

        public async Task CadastrarAsync(Vendedor vendedor)
        {
            if (vendedor != null)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<Vendedor> EditarAsyn(Vendedor vendedor)
        {
            if (_context.Vendedores.Any(v => v.Id == vendedor.Id))
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }

            return vendedor;
        }

        public async Task<Vendedor> ExcluirAsync(Vendedor vendedor)
        {
            if (_context.Vendedores.Any(v => v.Id == vendedor.Id))
            {
                _context.Remove(vendedor);
                await _context.SaveChangesAsync();
            }

            return vendedor;
        }

        public async Task<Vendedor> BuscarVendedorAsync(int id)
        {
            return await _context.Vendedores.FindAsync(id);
        }
    }
}