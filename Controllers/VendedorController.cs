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

        public IActionResult Index()
        {
            return View(_vendedorServicos.EncontrarTodos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _vendedorServicos.Cadastrar(vendedor);
                return RedirectToAction(nameof(Index));
            }

            return View(vendedor);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var vendedor = _vendedorServicos.BuscarVendedor(id.Value);
            if (vendedor == null)
                return RedirectToAction(nameof(Index));

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _vendedorServicos.Editar(vendedor);
                return RedirectToAction(nameof(Index));
            }

            return View(vendedor);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var vendedor = _vendedorServicos.BuscarVendedor(id.Value);
            if (vendedor == null)
                return RedirectToAction(nameof(Index));

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Vendedor vendedor)
        {
            _vendedorServicos.Excluir(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}