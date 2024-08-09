using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class VendedorController : Controller
    {
        private readonly SistemaVendaContext _context;

        public VendedorController(SistemaVendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vendedor = _context.Vendedores.ToList();
            return View(vendedor);
        }

        public IActionResult Cadastrar(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Vendedor vendedor)
        {
            if(ModelState.IsValid)
            {
                vendedor.Senha = "12345";
                _context.Vendedores.Add(vendedor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View(vendedor);
        }

        public IActionResult Editar(int id)
        {
            var vendedor = _context.Vendedores.Find(id);

            if(vendedor == null)
                return RedirectToAction(nameof(Index));
            
            return View(vendedor);
        }

        [HttpPost]
        public IActionResult Editar(Vendedor vendedor)
        {
            var vendedorBanco = _context.Vendedores.Find(vendedor.Id);

            vendedorBanco.Nome = vendedor.Nome;
            vendedorBanco.Email = vendedor.Email;

            _context.Vendedores.Update(vendedorBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





        public IActionResult Excluir(int id)
        {
            var vendedor = _context.Vendedores.Find(id);

            if(vendedor == null)
                return RedirectToAction(nameof(Index));

            return View(vendedor);
        }

        [HttpPost]
        public IActionResult Excluir(Vendedor vendedor)
        {
            var vendedorBanco = _context.Vendedores.Find(vendedor.Id);

            _context.Vendedores.Remove(vendedorBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}