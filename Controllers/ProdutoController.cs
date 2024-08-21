using Microsoft.AspNetCore.Mvc;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly SistemaVendaContext _context;

        public ProdutoController(SistemaVendaContext context)
        {   
            _context = context;
        }

        public IActionResult Index()
        {
            var produto = _context.Produtos.ToList();
            return View(produto);
        }

        public IActionResult Cadastrar()
        {
            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();

            return View(produto);
        }

        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
                return RedirectToAction(nameof(Index));
            
            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
                return View(produto);
            }

            var produtoBanco = _context.Produtos.Find(produto.Id);
            
            produtoBanco.Nome = produto.Nome;
            produtoBanco.Descricao = produto.Descricao;
            produtoBanco.PrecoUnitario = produto.PrecoUnitario;
            produtoBanco.QuantidadeEmEstoque = produto.QuantidadeEmEstoque;
            produtoBanco.UnidadeDeMedidaProduto = produto.UnidadeDeMedidaProduto;
            produtoBanco.Foto = produto.Foto;

            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
                return RedirectToAction(nameof(Index));

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        [HttpPost]
        public IActionResult Excluir(Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.Id);

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}