using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using ChicllaJean_CL2.Models;
using Newtonsoft.Json;

namespace ChicllaJean_CL2.Controllers
{
    public class RegistroAlumnoController : Controller
    {
        static string carpeta = "~/folder/";
        static string jalumno = "";

        public ActionResult SerializarRegistro(int op = 0)
        {
            if (op == 0)
            {
                return View(new Alumno());
            } else
            {
                try
                {
                    Alumno alumno = JsonConvert.DeserializeObject<Alumno>(jalumno);

                    return View(alumno);
                }
                catch (JsonException ex)
                {
                    ViewBag.mensaje = "No se pudo deserializr objeto Alumno";
                    ViewBag.exMessage = ex.Message;
                    return View(new Alumno());
                }

            }

        }
        [HttpPost]public ActionResult SerializarRegistro(Alumno reg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.mensaje = "Datos no válidos";
                return View(reg);
            }

            try
            {
                jalumno = JsonConvert.SerializeObject(reg);
                ViewBag.json = jalumno;

                string path = $"{ Server.MapPath(carpeta) }{ reg.nrodocumento}.json";

                FileStream f = new FileStream($"{path}", FileMode.Create);
                StreamWriter escritor = new StreamWriter(f);
                escritor.Write(jalumno);

                escritor.Close();
                f.Close();

                ViewBag.mensaje = $"Se creó un archivo json en {path} ";
                return View(new Alumno());

            } catch (JsonException ex)
            {
                ViewBag.mensaje = "No se pudo serializar objeto Alumno";
                ViewBag.exMessage = ex.Message;
                return View(reg);
            }
                
        }

    }
}