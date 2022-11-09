using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoVet.Data
{
    public class ProyectoVetContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ProyectoVetContext() : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ProyectoVet.Models.Administrador> Administradors { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Cita> Citas { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.HistoriaC> HistoriaCs { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Mascota> Mascotas { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Medico> Medicos { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Foro> Foros { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Respuesta> Respuestas { get; set; }
        public System.Data.Entity.DbSet<ProyectoVet.Models.Blog> Blogs { get; set; }


    }
}
