using BimboNicaragua.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BimboNicaragua.Controllers
{
    public class CMI_Controller : Controller
    {
        private readonly CMI_BimboContext _contextCMI;

        public CMI_Controller(CMI_BimboContext contextCMI)
        {
            _contextCMI = contextCMI;
        }
        public IActionResult Index()
        {
            return View();
        }// Fin del metodo Index

        public IActionResult Tabla_CMI()
        {
            var query = from O in _contextCMI.Objetivos
                        join I in _contextCMI.Indicadors on O.ObjetivoId equals I.ObjetivoId
                        join P in _contextCMI.Perspectivas on O.PerspectivaId equals P.PerspectivaId
                        join T in _contextCMI.Tipos on I.TipoId equals T.TipoId
                        join C in _contextCMI.Cmis on O.CmiId equals C.CmiId
                        select new
                        {
                            NombreDelObjetivo = O.Descripcion,
                            NombreDelIndicador = I.Nombre,
                            TipoDeIndicador = T.Nombre,
                            NombreDeLaPerspectiva = P.Nombre,
                            DescripcionDelCMI = C.Descripcion,
                            NombreDelCMI = C.Nombre,
                            PeriodoDelCMI = C.Periodo
                        };


            var tablacmi = query.ToList();

            return StatusCode(StatusCodes.Status200OK, tablacmi);
        }//Fin del metodo Tabla_CMI
    }
}
