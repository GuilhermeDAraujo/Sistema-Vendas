using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var venda = _context.Vendas
            .Include(v => v.Vendedor)
            .Include(v => v.Cliente)
            .ToList();
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
                    //Deserializa o Json enviado pela View, onde busco ele na minha Model Venda - ListaJSON
                    var listaProduto = JsonSerializer.Deserialize<ICollection<VendaProduto>>(venda.ListaProdutosJSON);

                    _context.Vendas.Add(venda);
                    _context.SaveChanges();

                    //Aqui o laço vai percerrer todos os itens da listaProduto(JSON), que já foi deserializada
                    foreach (var item in listaProduto)
                    {
                        //Aqui atribuo o Id da venda para a listaProduto(JSON) que veio sem o Id da venda, o Id veio do objeto venda que foi passado como parâmetro
                        item.VendaId = venda.Id;

                        //Adiciono os atributos na tabela VendaProduto
                        _context.VendaProdutos.Add(item);
                    }

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
            if (produto != null)
            {
                return Json(new { preco = produto.PrecoUnitario });
            }

            return Json(new { preco = 0 });
        }
    }
}
