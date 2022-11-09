using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class HistoriaC
    {
        [Key]
        public int HistoriaId { get; set; }

        //------------

        public int IdMascota { get; set; }
        public virtual Mascota mascota { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(30, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Edad { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(20, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Sexo { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(50, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Especie { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(50, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Dueno { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(100, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Correo { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(10, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Telefono { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(500, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Ciudad { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(500, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Dirección { get; set; }

        //------------

        public int IdMedico { get; set; }
        public virtual Medico medico { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(50, MinimumLength = 2,
           ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Especialidad { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(900, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        [DataType(DataType.MultilineText)]
        public string MotivoConsulta { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(900, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        [DataType(DataType.MultilineText)]
        public string Diagnostico { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(900, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(900, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        [DataType(DataType.MultilineText)]
        public string Recomendaciones { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Firma { get; set; }

        //------------
        [DataType(DataType.Date)]
        public String Fecha { get; set; }

        //------------

    }
}