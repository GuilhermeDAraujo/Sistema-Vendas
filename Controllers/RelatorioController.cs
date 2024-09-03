using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.Servicos;
using Projeto_Sistema_de_Vendas.ViewModels;

namespace Projeto_Sistema_de_Vendas.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly RelatorioServices _relatorio;

        public RelatorioController(RelatorioServices context)
        {
            _relatorio = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vendas()
        {   
            return View(new Relatorio()); //retorna a view com o modelo "Relatorio"
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vendas(Relatorio relatorio)
        {
            if(relatorio == null)
            {
                return BadRequest("Relatorio não pode ser nulo");
            }
            
            relatorio = await _relatorio.ConsultaAsync(relatorio);
            return View(relatorio);
        }

        public async Task<IActionResult> Vendedor()
        {
            await CarregarViewBag();
            return View(new Relatorio());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vendedor(Relatorio relatorio)
        {
            if(relatorio == null)
            {
                return BadRequest("Relatorio não pode ser nulo");
            }

            relatorio = await _relatorio.ConsultaVendedor(relatorio);

            await CarregarViewBag();
            return View(relatorio);
        }

        public async Task CarregarViewBag()
        {
            ViewBag.Vendedores = new SelectList(await _relatorio.EncontrarTodosVendedoresAsync(), "Id", "Nome");
        }
    }
}