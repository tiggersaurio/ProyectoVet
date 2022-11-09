using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class Blog
    {
        [Key]
        public int IdBlog { get; set; }


        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [DataType(DataType.Date)]
        public String FechaPublicacion { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        public string Titulo { get; set; }
        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(200, MinimumLength = 2,
        ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(900, MinimumLength = 2,
        ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        [DataType(DataType.MultilineText)]
        public string Contenido { get; set; }
    }
}