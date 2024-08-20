using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.ViewModels;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly SistemaVendaContext _context;

        public RelatorioController(SistemaVendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vendas()
        {
            var relatorio = new Relatorio();
            relatorio.DataAte = DateTime.Now;
            relatorio.DataDe = DateTime.Now;
            return View(relatorio); //retorna a view com o modelo "Relatorio"
        }

        [HttpPost]
        public IActionResult Vendas(Relatorio relatorio)
        {
            if (relatorio != null && ModelState.IsValid) //verifica se o objeto é não nulo e valido
            {
                relatorio.ListaVendas = _context.Vendas //busca as vendas no banco que estão dentro do filtro
                    .Where(v => v.DataVenda >= relatorio.DataDe && v.DataVenda <= relatorio.DataAte) //filtra as vendas pelo periodo datavenda Maior/Igual a dataDe e datavenda Menos/igual a dataAte
                    .Include(v => v.Vendedor) //inclui o vendedor na consulta
                    .Include(v => v.Cliente) //inclui o cliente na consulta
                    .ToList();
            }

            return View(relatorio);
        }

        public IActionResult Vendedor()
        {
            CarregarViewBag();
            return View(new RelatorioVendedor());
        }

        [HttpPost]
        public IActionResult Vendedor(RelatorioVendedor relatorio)
        {
            if (relatorio != null && ModelState.IsValid)
            {
                relatorio.ListaVendas = _context.Vendas
                    .Where(v => v.VendedorId == relatorio.ProcurarVendedorId)
                    .Include(v => v.Vendedor)
                    .Include(c => c.Cliente)
                    .ToList();
            }
            CarregarViewBag();
            return View(relatorio);
        }

        public void CarregarViewBag()
        {
            ViewBag.VendedorLista = new SelectList(_context.Vendedores.ToList(), "Id", "Nome");
        }
    }
}