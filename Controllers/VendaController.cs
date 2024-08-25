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

        public IActionResult Index()
        {
            return View(_vendaServicos.EncontrarTodasVendas());
        }

        public IActionResult Cadastrar()
        {
            CarregarViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                _vendaServicos.Cadastrar(venda);
                return RedirectToAction(nameof(Index));
            }

            CarregarViewBag();
            return View(venda);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var venda = _vendaServicos.EncontrarVenda(id.Value);
            if (venda == null)
                return RedirectToAction(nameof(Index));

            CarregarViewBag();
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Venda venda)
        {
            _vendaServicos.Excluir(venda);
            return RedirectToAction(nameof(Index));
        }

        public void CarregarViewBag()
        {
            ViewBag.Cliente = new SelectList(_vendaServicos.EncontrarTodosClientes(), "Id", "Nome");
            ViewBag.Vendedor = new SelectList(_vendaServicos.EncontrarTodosVendedores(), "Id", "Nome");
            ViewBag.Produto = new SelectList(_vendaServicos.EncontrarTodosProdutos(), "Id", "Nome");
        }

        public JsonResult GetPrecoProduto(int id)
        {
            var produto = _vendaServicos.EncontrarProduto(id);
            if (produto != null)
            {
                return Json(new { preco = produto.PrecoUnitario });
            }

            return Json(new { preco = 0 });
        }
    }
}
