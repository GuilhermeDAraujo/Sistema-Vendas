using Microsoft.AspNetCore.Mvc;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly SistemaVendaContext _context;

        public ClienteController(SistemaVendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cliente = _context.Clientes.ToList();
            return View(cliente);
        }    

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if(cliente != null && ModelState.IsValid)
            {
                cliente.Senha = "12345";
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }


        public IActionResult Editar(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if(cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cliente cliente)
        {
            if(!ModelState.IsValid)
            {
                return View(cliente);
            }
            var clienteBanco = _context.Clientes.Find(cliente.Id);

            clienteBanco.Nome = cliente.Nome;
            clienteBanco.CpfCnpj = cliente.CpfCnpj;
            clienteBanco.Email = cliente.Email;
            clienteBanco.Senha = cliente.Senha;

            _context.Clientes.Update(clienteBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if(cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Cliente cliente)
        {
            var clienteBanco = _context.Clientes.Find(cliente.Id);
            
            _context.Clientes.Remove(clienteBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}