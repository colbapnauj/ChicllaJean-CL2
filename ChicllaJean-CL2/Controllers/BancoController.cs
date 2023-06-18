using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using ChicllaJean_CL2.Models;

namespace ChicllaJean_CL2.Controllers
{
    public class BancoController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();
        IEnumerable<Cliente> obtenerClientes()
        {
            return clientes;
        }

        public ActionResult Listado()
        {
            return View(obtenerClientes());
        }

        public ActionResult Create()
        {
            return View(new Cliente());
        }

        [HttpPost] public ActionResult Create(Cliente reg)
        {
            reg.id = clientes.Count() == 0 ? 1 : clientes.Count() + 1;
            clientes.Add(reg);

            ViewBag.mensaje = "Registro exitoso";
            return RedirectToAction("Listado");
        }

        public ActionResult Details(int id)
        {
            Cliente reg = obtenerClientes().FirstOrDefault(c => c.id == id);
            return View(reg);
        }

        public ActionResult Depositar(int id)
        {
            Cliente reg = obtenerClientes().FirstOrDefault(c => c.id == id);
            return View(reg);
        }

        [HttpPost] public ActionResult Depositar(double montoDeposito, int clientId)
        {

            Cliente cliente = obtenerClientes().FirstOrDefault(c => c.id == clientId);

            cliente.Depositar(montoDeposito);

            int index = clientes.IndexOf(cliente);


            clientes[index] = cliente;

            ViewBag.mensaje = $"Se depositó {montoDeposito}";
            return View(cliente);
        }

        public ActionResult Retirar(int id)
        {
            Cliente reg = obtenerClientes().FirstOrDefault(c => c.id == id);
            return View(reg);
        }

        [HttpPost]
        public ActionResult Retirar(double montoRetiro, int clientId)
        {

            Cliente cliente = obtenerClientes().FirstOrDefault(c => c.id == clientId);

            if (montoRetiro > cliente.RetornarMonto())
            {
                ViewBag.mensaje = "Saldo insuficiente";
                return View(cliente);
            }

            cliente.Extraer(montoRetiro);

            int index = clientes.IndexOf(cliente);


            clientes[index] = cliente;

            ViewBag.mensaje = $"Se retiró {montoRetiro}";
            return View(cliente);
        }
    }
}