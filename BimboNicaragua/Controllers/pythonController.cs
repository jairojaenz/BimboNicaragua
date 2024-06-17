using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;


namespace BimboNicaragua.Controllers
{
    public class pythonController : Controller
    {
        // GET: pythonController
        public ActionResult Index()
        {
            return View();
        }

        // Código para ejecutar un script de Python en ASP.NET Core
        private readonly IWebHostEnvironment _env;
        // Inyectar IWebHostEnvironment en el constructor
        public pythonController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public ActionResult pyEdaDW()
        {
            try
            {
                var pythonPath = "python"; // Asegúrate de que esta ruta sea correcta para tu entorno
                                           // Construir la ruta al script de Python usando IWebHostEnvironment y la ruta relativa
                var scriptPath = Path.Combine(_env.ContentRootPath, "pyScripts", "pyEdaSQL.py");

                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = pythonPath;
                    myProcess.StartInfo.Arguments = $"\"{scriptPath}\""; // Asegúrate de incluir argumentos si son necesarios
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.StartInfo.RedirectStandardError = true;

                    myProcess.Start();

                    // Esperar a que el proceso termine
                    myProcess.WaitForExit();

                    // Leer la salida estándar y de error
                    string output = myProcess.StandardOutput.ReadToEnd();
                    string error = myProcess.StandardError.ReadToEnd();

                    // Verificar si hubo errores
                    if (!string.IsNullOrEmpty(error))
                    {
                        ViewBag.Error = "Error: " + error;
                    }
                    else
                    {
                        // Aquí puedes manejar la salida de tu script
                        ViewBag.Message = output.Trim();
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }
        //#######################################################################################################################################################################################


        public ActionResult pyEdaTemp()
        {
            try
            {
                var pythonPath = "python"; // Ruta al ejecutable de Python, puede variar según tu instalación
                                           // Usar IWebHostEnvironment para obtener las rutas
                var scriptPath = Path.Combine(_env.WebRootPath, "pyScripts", "pyEdaSQLTemp.py");
                var tempFilePath = Path.Combine(_env.WebRootPath, "App_Data", "Output.html"); // Archivo temporal para almacenar la salida

                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = pythonPath;
                    myProcess.StartInfo.Arguments = $"\"{scriptPath}\" \"{tempFilePath}\""; // Pasar la ruta del archivo temporal como argumento
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.StartInfo.RedirectStandardError = true;

                    myProcess.Start();

                    // Esperar a que el proceso termine
                    myProcess.WaitForExit();

                    // Leer la salida estándar y de error
                    string output = myProcess.StandardOutput.ReadToEnd();
                    string error = myProcess.StandardError.ReadToEnd();

                    // Verificar si hubo errores
                    if (!string.IsNullOrEmpty(error))
                    {
                        ViewBag.Error = "Error: " + error;
                    }
                    else
                    {
                        // Leer el contenido del archivo temporal
                        string fileContent = System.IO.File.ReadAllText(tempFilePath);
                        ViewBag.Message = fileContent;
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }
        //#######################################################################################################################################################################################

     



        // GET: pythonController/Delete/5

    }
}
