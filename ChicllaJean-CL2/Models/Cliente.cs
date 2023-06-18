using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChicllaJean_CL2.Models
{
    public class Cliente
    {
        public int id { get; set; }
        [Display(Name = "Nombe")] public string nombre { get; set; }
        [Display(Name = "Monto")] public double monto { get; set; }

        public Cliente()
        {
            id = 0;
            nombre = string.Empty;
            monto = 0;
        }
        

        public Cliente(string nombre, double monto)
        {
            this.nombre = nombre;
            this.monto = monto;
        }

        public void Depositar(double valor)
        {
            this.monto += valor;
        }

        public void Extraer(double valor)
        {
            if (valor > this.monto)
            {
                return;
            }

            this.monto -= valor;
        } 

        public double RetornarMonto()
        {
            return this.monto;
        }
    }
}