using Microsoft.AspNetCore.Mvc;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.Servicos;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoServicos _produtoServico;

        public ProdutoController(ProdutoServicos produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public IActionResult Index()
        {
            return View(_produtoServico.EncontrarTodos());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoServico.Cadastrar(produto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));


            var produto = _produtoServico.BuscarProduto(id.Value);
            if (produto == null)
                return RedirectToAction(nameof(Index));

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoServico.Editar(produto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        public IActionResult Excluir(int? id)
        {
            if(id == null)
                return RedirectToAction(nameof(Index));

            var produto = _produtoServico.BuscarProduto(id.Value);
            if (produto == null)
                return RedirectToAction(nameof(Index));

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _produtoServico.Excluir(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }
    }
}