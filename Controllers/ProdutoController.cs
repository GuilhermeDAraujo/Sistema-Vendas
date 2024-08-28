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

        public async Task<IActionResult> Index()
        {
            return View(await _produtoServico.EncontrarTodosAsync());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoServico.CadastrarAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));


            var produto = await _produtoServico.BuscarProdutoAsync(id.Value);
            if (produto == null)
                return RedirectToAction(nameof(Index));

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoServico.EditarAsync(produto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var produto = await _produtoServico.BuscarProdutoAsync(id.Value);
            if (produto == null)
                return RedirectToAction(nameof(Index));

            ViewBag.UnidadeDeMedidaProduto = Produto.GetUnidadeDeMedidaOpcoes();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Produto produto)
        {
            await _produtoServico.ExcluirAsync(produto);
            return RedirectToAction(nameof(Index));
        }
    }
}