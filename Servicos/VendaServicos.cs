using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Servicos
{
    public class VendaServicos
    {
        private readonly SistemaVendaContext _context;

        public VendaServicos(SistemaVendaContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> EncontrarTodasVendasAsync()
        {
            return await _context.Vendas
            .Include(v => v.Vendedor)
            .Include(v => v.Cliente)
            .OrderByDescending(v => v.DataVenda)
            .ToListAsync();
        }

        public async Task<bool> CadastrarAsync(Venda venda)
        {
            if (venda == null)
            {
                return false;
            }

            //Desserializa o Json enviado pela View, onde busco ele na minha Model Venda - ListaJSON
            var listaProduto = JsonSerializer.Deserialize<ICollection<VendaProduto>>(venda.ListaProdutosJSON);

            //Adiciona a venda na tabela Venda
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            foreach (var item in listaProduto) //Aqui o laço vai percerrer todos os itens da listaProduto(JSON), que já foi deserializada
            {
                var produto = await _context.Produtos.FindAsync(item.ProdutoId); //Atribui para a var produto o ProdutoId que veio da ListaJSON

                if (produto == null || produto.QuantidadeEmEstoque < item.QuantidadeVendida) //Se o produto for nulo ou nao tiver quantidade suficiente em estoque
                {
                    return false; // Retorna falso se o produto não existir ou não tiver estoque suficiente
                }

                produto.QuantidadeEmEstoque -= item.QuantidadeVendida;
                _context.Produtos.Update(produto);

                item.VendaId = venda.Id; //Aqui atribuo o Id da venda para a listaProduto(JSON) que veio sem o Id da venda, o Id veio do objeto venda que foi passado como parâmetro
                _context.VendaProdutos.Add(item); //Adiciono os atributos na tabela VendaProduto
            }
            await _context.SaveChangesAsync();
            return true;
        }

        

    public async Task<Venda> ExcluirAsync(Venda venda)
    {
        if (_context.Vendas.Any(v => v.Id == venda.Id))
        {
            _context.Remove(venda);
            await _context.SaveChangesAsync();
        }
        return venda;
    }

    public async Task<List<Cliente>> EncontrarTodosClientesAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<List<Vendedor>> EncontrarTodosVendedoresAsync()
    {
        return await _context.Vendedores.ToListAsync();
    }

    public async Task<List<Produto>> EncontrarTodosProdutosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Venda> EncontrarVendaAsync(int id)
    {
        return await _context.Vendas
        .Include(v => v.Cliente)
        .Include(v => v.Vendedor)
        .Include(vp => vp.VendaProdutos)
            .ThenInclude(p => p.Produto)
        .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Produto> EncontrarProdutoAsync(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }
}
}