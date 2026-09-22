using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExerciciosMVC.Models;

namespace ExerciciosMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Idade(int id)
    {
        if (id == 0 || id == null)
        {
            ViewBag.Idade = -1;
        }
        else
        {
            ViewBag.Idade = DateTime.Now.Year - id;
        }
        return View();
    }

    [HttpGet("/Home/Soma/{a?}/{b?}")]
    public IActionResult Soma(int? a, int? b)
    {
        ViewBag.Resultado = a+b;
        return View();
    }

    public IActionResult Tarefas()
    {
        var tarefas = new List<string> { "Estudar", "Praticar" };
        ViewBag.Tarefas = tarefas;
        return View();
    }
    
    [HttpGet] public IActionResult Contacto() => View();

    [HttpPost]
    public IActionResult Contacto(string? nome)
    {
        ViewBag.Nome = nome ?? "Desconhecido";
        return View();
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}