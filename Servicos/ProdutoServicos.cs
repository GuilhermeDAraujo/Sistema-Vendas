using System.Globalization;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Produto>> EncontrarTodosAsync()
        {
            return await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task CadastrarAsync(Produto produto)
        {
            if (produto != null)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Produto> EditarAsync(Produto produto)
        {
            if (_context.Produtos.Any(p => p.Id == produto.Id))
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }

            return produto;
        }

        public async Task<Produto> ExcluirAsync(Produto produto)
        {
            if (_context.Produtos.Any(p => p.Id == produto.Id))
            {
                _context.Remove(produto);
                await _context.SaveChangesAsync();
            }

            return produto;
        }

        public async Task<Produto> BuscarProdutoAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

    }
}