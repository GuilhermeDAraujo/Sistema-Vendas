using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.Servicos;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class VendaController : Controller
    {
        private readonly VendaServicos _vendaServicos;

        public VendaController(VendaServicos vendaServicos)
        {
            _vendaServicos = vendaServicos;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vendaServicos.EncontrarTodasVendasAsync());
        }

        public async Task<IActionResult> Cadastrar()
        {
            await CarregarViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                await _vendaServicos.CadastrarAsync(venda);
                return RedirectToAction(nameof(Index));
            }

            await CarregarViewBag();
            return View(venda);
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var venda = await _vendaServicos.EncontrarVendaAsync(id.Value);
            if (venda == null)
                return RedirectToAction(nameof(Index));

            await CarregarViewBag();
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Venda venda)
        {
            await _vendaServicos.ExcluirAsync(venda);
            return RedirectToAction(nameof(Index));
        }

        public async Task CarregarViewBag()
        {
            ViewBag.Cliente = new SelectList(await _vendaServicos.EncontrarTodosClientesAsync(), "Id", "Nome");
            ViewBag.Vendedor = new SelectList(await _vendaServicos.EncontrarTodosVendedoresAsync(), "Id", "Nome");
            ViewBag.Produto = new SelectList(await _vendaServicos.EncontrarTodosProdutosAsync(), "Id", "Nome");
        }

        public async Task<JsonResult> GetPrecoProduto(int id)
        {
            var produto = await _vendaServicos.EncontrarProdutoAsync(id);
            if (produto != null)
            {
                return Json(new { preco = produto.PrecoUnitario });
            }

            return Json(new { preco = 0 });
        }
    }
}
