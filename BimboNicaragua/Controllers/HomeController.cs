using BimboNicaragua.Models;
using BimboNicaragua.Models.BimboModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace BimboNicaragua.Controllers
{
    public class HomeController : Controller
    {
        private readonly PanPlusBimboContext _context;

        public HomeController(PanPlusBimboContext context)
        {
            _context = context;
        }

        public IActionResult VentasMensuales()
        {
            DateTime fechaV = DateTime.Now; //Obtener hasta la fecha actual
            DateTime f_Año = fechaV.AddMonths(-12);
            List<BModelsVenta> InfVentas = _context.Ventas
            .Where(v => v.FechaVenta.Date >= f_Año.Date && v.FechaVenta.Date <= fechaV)
            .GroupBy(v => new { v.FechaVenta.Year, v.FechaVenta.Month })
            .Select(g => new {
                Year = g.Key.Year,
                Month = g.Key.Month,
                Total = g.Sum(v => v.MontoTotal)
            })
            .AsEnumerable() // Fetch data from the database
             .Select(g => new BModelsVenta
            {
            fechaVenta = new DateTime(g.Year, g.Month, 1).ToString("MMMM yyyy", new CultureInfo("es-ES")),
                 Total = g.Total
            })
            .OrderBy(v => DateTime.ParseExact(v.fechaVenta, "MMMM yyyy", new CultureInfo("es-ES")))
            .ToList();
            return StatusCode(StatusCodes.Status200OK, InfVentas);

        }//Fin de VentasTrimestrales
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
    }
}
