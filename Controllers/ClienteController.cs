using Microsoft.AspNetCore.Mvc;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.Servicos;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteServicos _clienteServicos;

        public ClienteController(ClienteServicos clienteServicos)
        {
            _clienteServicos = clienteServicos;
        }

        public IActionResult Index()
        {
            return View(_clienteServicos.EncontrarTodos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteServicos.Cadastrar(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }


        public IActionResult Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var cliente = _clienteServicos.BuscarCliente(id.Value);
            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteServicos.Editar(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var cliente = _clienteServicos.BuscarCliente(id.Value);
            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteServicos.Excluir(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }
    }
}