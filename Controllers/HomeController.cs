using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_CZERNUSZKA_KOZIUPA.Models;

namespace TP05_CZERNUSZKA_KOZIUPA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Habitacion(int sala, string clave){
        if(sala == Escape.GetEstadoJuego()){
            if(Escape.ResolverSala(sala, clave)){
                if(Escape.GetEstadoJuego() > 4) return View("Victoria");
                else return View("Habitacion"+Escape.GetEstadoJuego());
            }
            else{
                ViewBag.Error = "Respuesta Incorrecta";
                return View("Habitacion"+Escape.GetEstadoJuego());
            }
        }
        else return View("Habitacion"+Escape.GetEstadoJuego());
    }
    public IActionResult Comenzar(){
        return View("Habitacion"+1);
    }
    public IActionResult Tutorial(){
        return View();
    }
    public IActionResult Victoria(){
        ViewBag.intentos = Escape.GetCantIntentos();
        return View();
    }
    public IActionResult Creditos(){
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
