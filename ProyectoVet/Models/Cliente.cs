using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Nombres { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerid o")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Apellidos { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(10, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Documento { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = " El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Email { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [Range(3000000000, 3999999999, ErrorMessage = "Ingrese un número de celular válido")]
        public string Telefono { get; set; }

        //------------

        [Required(ErrorMessage = "El campo {0}, es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //------------

        // elemento para establecer la relacion con mascotas
        public virtual ICollection<Mascota> mascotas { get; set; }

    }
}