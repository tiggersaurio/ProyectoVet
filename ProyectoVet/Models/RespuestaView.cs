using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class RespuestaView
    {
        public int ForoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(1000, MinimumLength = 1,
        ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string RespuestaForo { get; set; }
    }
}