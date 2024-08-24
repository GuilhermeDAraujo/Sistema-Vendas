using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_Sistema_de_Vendas.Context;
using Projeto_Sistema_de_Vendas.Models;
using Projeto_Sistema_de_Vendas.ViewModels;

namespace Projeto_Sistema_de_Vendas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SistemaVendaContext _context;

    public HomeController(ILogger<HomeController> logger, SistemaVendaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Login()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel login)
    {
        if(ModelState.IsValid)
        {   
            var vendedor = _context.Vendedores.FirstOrDefault(v => v.Email == login.Email && v.Senha == login.Senha);

            if(vendedor != null)
            {
                HttpContext.Session.SetString("IdUsuarioLogado",vendedor.Id.ToString());
                HttpContext.Session.SetString("NomeUsuarioLogado",vendedor.Nome);
                return RedirectToAction(nameof(Menu));
            }
            else
            {
                TempData ["ErrorLogin"] = "E-mail ou senha são inválidos!";
            }
            
        }
        return View(login);  
    }
    public IActionResult Menu()
    {
        return View();
    }
}
