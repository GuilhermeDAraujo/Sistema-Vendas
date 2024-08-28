using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Servicos
{
    public class ClienteServicos
    {
        private readonly SistemaVendaContext _context;

        public ClienteServicos(SistemaVendaContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> EncontrarTodosAsync()
        {
            return await _context.Clientes.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task CadastrarAsync(Cliente cliente)
        {
            if (cliente != null)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente> EditarAsync(Cliente cliente)
        {
            if(_context.Clientes.Any(c => c.Id == cliente.Id))
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }

            return cliente;
        }

        public async Task<Cliente> ExcluirAsync(Cliente cliente)
        {
            if(_context.Clientes.Any(c => c.Id == cliente.Id))
            {
                _context.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return cliente;
        }

        public async Task<Cliente> BuscarClienteAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
    }
}