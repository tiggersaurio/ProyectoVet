using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVet.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(12, MinimumLength = 1,
           ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, MinimumLength = 1,
            ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}