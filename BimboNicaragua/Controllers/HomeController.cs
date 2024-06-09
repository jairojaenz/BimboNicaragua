﻿using BimboNicaragua.Models;
using BimboNicaragua.Models.BimboModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            DateTime fechaV = DateTime.Now;
            DateTime f_Año = fechaV.AddMonths(-12);
            List<BModelsVenta> InfVentas = _context.Ventas
                .Where(v => v.FechaVenta.Date >= f_Año.Date && v.FechaVenta.Date <= fechaV)
                .GroupBy(v => new { v.FechaVenta.Year, v.FechaVenta.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Total = g.Sum(v => v.MontoTotal)
                })
                .AsEnumerable()
                .Select(g => new BModelsVenta
                {
                    fechaVenta = new DateTime(g.Year, g.Month, 1).ToString("MMMM yyyy", new CultureInfo("es-ES")),
                    Total = g.Total
                })
                .OrderBy(v => DateTime.ParseExact(v.fechaVenta, "MMMM yyyy", new CultureInfo("es-ES")))
                .ToList();
            return StatusCode(StatusCodes.Status200OK, InfVentas);
        }

        public IActionResult VentasTrimestrales()
        {
            var añoPasado = DateTime.Now.Year - 1;

            List<BModelsVenta> listaVentas = _context.Ventas
                .Where(v => v.FechaVenta.Year == añoPasado)
                .GroupBy(v => new { v.FechaVenta.Year, Quarter = ((v.FechaVenta.Month - 1) / 3) + 1 })
                .Select(g => new
                {
                    Quarter = g.Key.Quarter,
                    Year = g.Key.Year,
                    Total = (Int32)g.Sum(v => v.MontoTotal),
                })
                .AsEnumerable()
                .Select(g => new BModelsVenta
                {
                    fechaVenta = $"Trimestre {g.Quarter} {g.Year}",
                    Total = g.Total,
                })
                .OrderBy(v => v.fechaVenta)
                .ToList();
            return StatusCode(StatusCodes.Status200OK, listaVentas);
        }

        public IActionResult VentasSemanales()
        {
            var añoActual = DateTime.Now.Year;

            List<BModelsVenta> listaVentas = _context.Ventas
                .Where(v => v.FechaVenta.Year == añoActual)
                .AsEnumerable()
                .GroupBy(v => new { Week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(v.FechaVenta, CalendarWeekRule.FirstDay, DayOfWeek.Monday) })
                .Select(g => new BModelsVenta
                {
                 fechaVenta = $"Semana {g.Key.Week}",
                 Total = (Int32)g.Sum(v => v.MontoTotal),
                })
                .OrderBy(v => int.Parse(v.fechaVenta.Split(' ')[1]))
                .ToList();
            return StatusCode(StatusCodes.Status200OK, listaVentas);
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
    }
}
