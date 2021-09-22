using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoTp2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace ProyectoTp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Empleado()
        {

            return View();
        }
        public IActionResult VerEmpleado(string nombre, string apellido,string dire, string Fna, string Fing, string titulo, long matri)
        {
            try
            {
                DateTime fechaNa =  DateTime.Parse(Fna);
                DateTime fechaing =  DateTime.Parse(Fing);
                if (nombre!=null && apellido!=null && dire!=null &&titulo!=null)
                {
                    Empleado empleado = new Empleado(nombre,apellido,dire,fechaNa,fechaing,titulo,matri);
                    int antiguedad = empleado.DevolverAntiguedad();
                    int edad = empleado.EdadEmpleado();
                    double salario = empleado.SalarioEmpleado();
                    logger.Info("Datos del empleado: "+ " name: " + nombre + " Apelldio: " + apellido + " Edad: " + edad +" Salario: " + salario + " Antiguedad" + antiguedad );
                    
                }
                else
                {
                    throw new ArgumentNullException("Parameters can't be null.");
                }
               
                
            }
            catch (Exception ex)
            {
                
                logger.Error(ex.Message);
               
            }

            return View();
        }
       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
