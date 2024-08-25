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

        public List<Venda> EncontrarTodasVendas()
        {
            return _context.Vendas
            .Include(v => v.Vendedor)
            .Include(v => v.Cliente)
            .OrderByDescending(v => v.DataVenda)
            .ToList();
        }

        public Venda Cadastrar(Venda venda)
        {
            if (venda != null)
            {
                //Desserializa o Json enviado pela View, onde busco ele na minha Model Venda - ListaJSON
                var listaProduto = JsonSerializer.Deserialize<ICollection<VendaProduto>>(venda.ListaProdutosJSON);

                _context.Vendas.Add(venda);
                _context.SaveChanges();
                foreach (var item in listaProduto) //Aqui o laço vai percerrer todos os itens da listaProduto(JSON), que já foi deserializada
                {
                    item.VendaId = venda.Id; //Aqui atribuo o Id da venda para a listaProduto(JSON) que veio sem o Id da venda, o Id veio do objeto venda que foi passado como parâmetro
                    _context.VendaProdutos.Add(item); //Adiciono os atributos na tabela VendaProduto
                }
                _context.SaveChanges();
            }
            return venda;
        }

        public Venda Excluir(Venda venda)
        {
            if(_context.Vendas.Any(v => v.Id == venda.Id))
            {
                _context.Remove(venda);
                _context.SaveChanges();
            }
            return venda;
        }

        public List<Cliente> EncontrarTodosClientes()
        {
            return _context.Clientes.ToList();
        }

        public List<Vendedor> EncontrarTodosVendedores()
        {
            return _context.Vendedores.ToList();
        }

        public List<Produto> EncontrarTodosProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Venda EncontrarVenda(int id)
        {
            return _context.Vendas
            .Include(v => v.Cliente)
            .Include(v => v.Vendedor)
            .Include(vp => vp.VendaProdutos)
                .ThenInclude(p => p.Produto)
            .FirstOrDefault(v => v.Id == id);
        }

        public Produto EncontrarProduto(int id)
        {
            return _context.Produtos.Find(id);
        }
    }
}