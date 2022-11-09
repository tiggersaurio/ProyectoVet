using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Nombres { get; set; }

        //------------
        //Select especie
        [Required(ErrorMessage = "El campo {0}, es requerido")]
        public string Especie { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        public String Edad { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Especificaciones { get; set; }

        //------------

        public int IdCliente { get; set; }
        public virtual Cliente cliente { get; set; }


        //------------

        // elemento para establecer la relacion con cita
        public virtual ICollection<Cita> citas { get; set; }

        // elemento para establecer la relacion con historia clinica
        public virtual ICollection<HistoriaC> historiaCs { get; set; }

        //------------
    }
}