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

        public IActionResult VentasMensuales()  //Metodo para obtener las ventas mensuales
        {
            DateTime fechaV = DateTime.Now; //Obtener hasta la fecha actual
            DateTime f_Año = fechaV.AddMonths(-12); //Obtener la fecha de hace un año
            List<BModelsVenta> InfVentas = _context.Ventas  //Consulta a la base de datos
            .Where(v => v.FechaVenta.Date >= f_Año.Date && v.FechaVenta.Date <= fechaV) //Filtrar por fecha
            .GroupBy(v => new { v.FechaVenta.Year, v.FechaVenta.Month })    //Agrupar por año y mes
            .Select(g => new {  //Seleccionar los datos
                Year = g.Key.Year,  //Año
                Month = g.Key.Month,    //Mes
                Total = g.Sum(v => v.MontoTotal)    //Total de ventas
            })  //Fin de Select
            .AsEnumerable() //Convertir a una lista enumerable
             .Select(g => new BModelsVenta //seleccionar los datos
            {
            fechaVenta = new DateTime(g.Year, g.Month, 1).ToString("MMMM yyyy", new CultureInfo("es-ES")),  //Fecha de la venta 
                 Total = g.Total    //Total de ventas
            })
            .OrderBy(v => DateTime.ParseExact(v.fechaVenta, "MMMM yyyy", new CultureInfo("es-ES"))) //Ordenar por fecha
            .ToList();  //Convertir a lista
            return StatusCode(StatusCodes.Status200OK, InfVentas);  //Retornar la lista

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
