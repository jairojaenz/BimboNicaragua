using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


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
                var pythonPath = "python"; // Ruta al ejecutable de Python, puede variar según tu instalación
                var scriptPath = Path.Combine(_env.ContentRootPath, "pyScripts", "pyEdaSQL.py");
                var appDataPath = Path.Combine(_env.ContentRootPath, "App_Data");

                // Crear la carpeta App_Data si no existe
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }

                var tempFilePath = Path.Combine(appDataPath, "Output.html"); // Archivo temporal para almacenar la salida

                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = pythonPath;
                    myProcess.StartInfo.Arguments = $"{scriptPath} {tempFilePath}"; // Pasar la ruta del archivo temporal como argumento
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
                    }// Fin del if
                    else
                    {
                        // Leer el contenido del archivo temporal
                        string fileContent = System.IO.File.ReadAllText(tempFilePath);
                        ViewBag.Message = fileContent;
                    }//Fin del else
                }
            }//Fin del try
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }//Fin del catch
            return View();

        }//Fin del metodo pyEdaDW

        public ActionResult pyEdaSQLCMI()
        {
            try
            {
                var pythonPath = "python"; // Ruta al ejecutable de Python, puede variar según tu instalación
                var scriptPath = Path.Combine(_env.ContentRootPath, "pyScripts", "pyEdaSqlCMI.py");
                var appDataPath = Path.Combine(_env.ContentRootPath, "App_Data");

                // Crear la carpeta App_Data si no existe
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }

                var tempFilePath = Path.Combine(appDataPath, "Output.html"); // Archivo temporal para almacenar la salida

                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = pythonPath;
                    myProcess.StartInfo.Arguments = $"{scriptPath} {tempFilePath}"; // Pasar la ruta del archivo temporal como argumento
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
                    }// Fin del if
                    else
                    {
                        // Leer el contenido del archivo temporal
                        string fileContent = System.IO.File.ReadAllText(tempFilePath);
                        ViewBag.Message = fileContent;
                    }//Fin del else
                }
            }//Fin del try
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }//Fin del catch
            return View();

        }//Fin del metodo pyEdaSQL
       
     
    }
}
