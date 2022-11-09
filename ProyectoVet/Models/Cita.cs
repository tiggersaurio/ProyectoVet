using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        //------------

        public int IdMedico { get; set; }
        public virtual Medico medico { get; set; }

        //------------

        public int IdMascota { get; set; }
        public virtual Mascota mascota { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [DataType(DataType.Date)]
        public String Fecha { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Hora { get; set; }

        //------------
        //Select categoria 1.General 2.Control 3.Cirugia 4.Spa

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        public string Categoria { get; set; }

        //------------
        //Select consultorio A1-A2-A3-B1-B2-B3-Cirugia 1-Cirugia 2-Spa 1-Spa 2-Spa 3-Spa 4

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        public string Consultorio { get; set; }



     
        //------------
    }
}