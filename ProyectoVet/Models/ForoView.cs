using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class ForoView
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(300, MinimumLength = 1,
          ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string NombreForo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(1000, MinimumLength = 1,
           ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Seccion { get; set; }
    }
}