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

        public List<Vendedor> EncontrarTodos()
        {
            return _context.Vendedores.ToList();
        }

        public void Cadastrar(Vendedor vendedor)
        {
            if (vendedor != null)
            {
                _context.Add(vendedor);
                _context.SaveChanges();

            }
        }

        public Vendedor Editar(Vendedor vendedor)
        {
            if (_context.Vendedores.Any(v => v.Id == vendedor.Id))
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }

            return vendedor;
        }

        public Vendedor Excluir(Vendedor vendedor)
        {
            if (_context.Vendedores.Any(v => v.Id == vendedor.Id))
            {
                _context.Remove(vendedor);
                _context.SaveChanges();
            }

            return vendedor;
        }

        public Vendedor BuscarVendedor(int id)
        {
            return _context.Vendedores.Find(id);
        }
    }
}