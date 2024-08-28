using Microsoft.AspNetCore.Mvc;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.Servicos;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class VendedorController : Controller
    {
        private readonly VendedorServicos _vendedorServicos;

        public VendedorController(VendedorServicos vendedorServicos)
        {
            _vendedorServicos = vendedorServicos;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vendedorServicos.EncontrarTodosAsync());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                await _vendedorServicos.CadastrarAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }

            return View(vendedor);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var vendedor = await _vendedorServicos.BuscarVendedorAsync(id.Value);
            if (vendedor == null)
                return RedirectToAction(nameof(Index));

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                await _vendedorServicos.EditarAsyn(vendedor);
                return RedirectToAction(nameof(Index));
            }

            return View(vendedor);
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var vendedor = await _vendedorServicos.BuscarVendedorAsync(id.Value);
            if (vendedor == null)
                return RedirectToAction(nameof(Index));

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Vendedor vendedor)
        {
            await _vendedorServicos.ExcluirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}