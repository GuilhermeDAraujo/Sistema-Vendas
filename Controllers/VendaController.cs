using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class VendaController : Controller
    {
        private readonly SistemaVendaContext _context;

        public VendaController(SistemaVendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var venda = _context.Vendas.ToList();
            return View(venda);
        }

        public IActionResult Cadastrar()
        {
            var model = new Venda
            {
                DataVenda = DateTime.Now
            };
            
            CarregarViewBag();
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastrar(Venda venda)
        {
            if (venda != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Vendas.Add(venda);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            CarregarViewBag();
            return View(venda);
        }

        public void CarregarViewBag()
        {
            ViewBag.Cliente = new SelectList(_context.Clientes.ToList(), "Id", "Nome");
            ViewBag.Vendedor = new SelectList(_context.Vendedores.ToList(), "Id", "Nome");
            ViewBag.Produto = new SelectList(_context.Produtos.ToList(), "Id", "Nome");
        }

        public JsonResult GetPrecoProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto != null)
            {
                return Json(new {preco = produto.PrecoUnitario});
            }

            return Json(new {preco = 0});
        }
    }
}
