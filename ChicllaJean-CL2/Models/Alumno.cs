using System.ComponentModel.DataAnnotations;

namespace ChicllaJean_CL2.Models
{
    public class Alumno
    {
        [Display(Name = "Número de documento")]public int nrodocumento { get; set; }
        [Display(Name = "Nombre")]public string nombre { get; set; }
        [Display(Name = "Fecha de Nacimiento")]public string fechanacimiento { get; set; }

    }
}