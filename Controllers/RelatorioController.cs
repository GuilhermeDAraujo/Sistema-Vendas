using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Context;
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
            return View(new RelatorioVendasDataViewModel()); //retorna a view com o modelo "Relatorio"
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vendas(RelatorioVendasDataViewModel relatorio)
        {
            if (relatorio != null && ModelState.IsValid) //verifica se o objeto é não nulo e valido
            {
                relatorio.ListaDeVendas = _context.Vendas //busca as vendas no banco que estão dentro do filtro
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
            return View(new RelatorioPorVendedorViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vendedor(RelatorioPorVendedorViewModel relatorio)
        {
            if (relatorio != null && ModelState.IsValid)
            {
                relatorio.ListaDeVendas = _context.Vendas
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