using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public IActionResult Cadastrar(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
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
    }
}