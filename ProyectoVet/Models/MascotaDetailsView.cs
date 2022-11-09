using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoVet.Models
{
    public class MascotaDetailsView
    {
        public int IdMascota { get; set; }
        public string Nombres { get; set; }
        public string Especie { get; set; }
        public string Edad { get; set; }
        public string Especificaciones { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente cliente { get; set; }

        public List<HistoriaC> HistoriaCs { get; set; }
    }
}