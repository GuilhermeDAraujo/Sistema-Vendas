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

        public List<Cliente> EncontrarTodos()
        {
            return _context.Clientes.ToList();
        }

        public void Cadastrar(Cliente cliente)
        {
            if (cliente != null)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }

        public Cliente Editar(Cliente cliente)
        {
            if(_context.Clientes.Any(c => c.Id == cliente.Id))
            {
                _context.Update(cliente);
                _context.SaveChanges();
            }

            return cliente;
        }

        public Cliente Excluir(Cliente cliente)
        {
            if(_context.Clientes.Any(c => c.Id == cliente.Id))
            {
                _context.Remove(cliente);
                _context.SaveChanges();
            }

            return cliente;
        }

        public Cliente BuscarCliente(int id)
        {
            return _context.Clientes.Find(id);
        }
    }
}