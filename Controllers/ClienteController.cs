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

        public async Task<IActionResult> Index()
        {
            return  View(await _clienteServicos.EncontrarTodosAsync());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteServicos.CadastrarAsync(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }


        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var cliente = await _clienteServicos.BuscarClienteAsync(id.Value);
            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            await _clienteServicos.EditarAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var cliente = await _clienteServicos.BuscarClienteAsync(id.Value);
            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteServicos.ExcluirAsync(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }
    }
}