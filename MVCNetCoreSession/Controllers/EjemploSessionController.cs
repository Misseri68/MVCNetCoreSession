using Microsoft.AspNetCore.Mvc;
using MVCNetCoreSession.Extensions;
using MVCNetCoreSession.Helpers;
using MVCNetCoreSession.Models;

namespace MVCNetCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        HelperSessionContextAccessor helperSessionCA;
        public EjemploSessionController(HelperSessionContextAccessor helperSessionCA) { 
        this.helperSessionCA = helperSessionCA;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SessionCollection(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota{Nombre = "Nala", Raza = "Leona", Edad = 19 },
                        new Mascota{Nombre = "Nemo", Raza = "Pez", Edad = 1 },
                        new Mascota{Nombre = "Timon", Raza = "Suricata", Edad = 19 }
                    };
                    byte[] data = HelperBinarySession.ObjectToByte(mascotas);
                    HttpContext.Session.Set("MASCOTAS", data);
                    ViewData["MENSAJE"] = "INTRODUCIDOS NAIMALES";
                    return View();
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTAS");
                    List<Mascota> mascotas = (List<Mascota>)HelperBinarySession.ByteToObject(data);
                    return View(mascotas);
                }
            }
            return View();
        }

        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora",
                        DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados en session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }

        public IActionResult SessionMascota(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Flounder";
                    mascota.Raza = "pez";
                    mascota.Edad = 5;
                    byte[] data = HelperBinarySession.ObjectToByte(mascota);

                    HttpContext.Session.Set("MASCOTA", data);

                    ViewData["MENSAJE"] = "Datos almacenados en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    Mascota mascota = (Mascota)HelperBinarySession.ByteToObject(data);
                    ViewData["MENSAJE"] = "Info mascota : " + mascota.Nombre;
                }
            }
            return View();
        }


        public IActionResult SessionMascotaJson(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "mostrar")
                {
                    string jsonMascota = HttpContext.Session.GetString("MASCOTA");
                    Mascota mascota = HelperJsonSession.DeserializeObject<Mascota>(jsonMascota);
                    ViewData["MASCOTA"] = mascota;
                }
                else if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota { Nombre = "Simba", Edad = 3, Raza = "Leon" };
                    string jsonMascota = HelperJsonSession.SerializeObject(mascota);
                    HttpContext.Session.SetString("MASCOTA", jsonMascota);
                    ViewData["MENSAJE"] = "Mascota JSON almacenada";
                }
            }
            return View();
        }

        public IActionResult SessionMascotaCollection(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "mostrar")
                {
                    List<Mascota> mascotas = HttpContext.Session.GetObject<List<Mascota>>("MASCOTAS");
                    return View(mascotas);
                }
                else if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota { Nombre = "Patricio", Edad = 4, Raza = "Estrella" },
                        new Mascota { Nombre = "Bob", Edad = 3, Raza = "Esponja" },
                        new Mascota { Nombre = "Bolt", Edad = 2, Raza = "Perro" },
                        new Mascota { Nombre = "Zazu", Edad = 8, Raza = "Pájaro" }
                    };

                    HttpContext.Session.SetObject("MASCOTAS", mascotas);
                    ViewData["MENSAJE"] = "Subidas mascotas a Session";
                }
            }
            return View();

        }
    }        
}
