using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class ForoDetailsView
    {
        public int ForoId { get; set; }
        public string NombreForo { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Seccion { get; set; }
        public List<Respuesta> Respuestas { get; set; }
        public virtual ICollection<Respuesta> respuestas { get; set; }
    }
}