using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Servicos
{
    public class ProdutoServicos
    {
        private readonly SistemaVendaContext _context;

        public ProdutoServicos(SistemaVendaContext context)
        {
            _context = context;
        }

        public List<Produto> EncontrarTodos()
        {
            return _context.Produtos.ToList();
        }

        public void Cadastrar(Produto produto)
        {
            if (produto != null)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
        }

        public Produto Editar(Produto produto)
        {
            if (_context.Produtos.Any(p => p.Id == produto.Id))
            {
                _context.Update(produto);
                _context.SaveChanges();
            }

            return produto;
        }

        public Produto Excluir(Produto produto)
        {
            if (_context.Produtos.Any(p => p.Id == produto.Id))
            {
                _context.Remove(produto);
                _context.SaveChanges();
            }

            return produto;
        }

        public Produto BuscarProduto(int id)
        {
            return _context.Produtos.Find(id);
        }
    }
}