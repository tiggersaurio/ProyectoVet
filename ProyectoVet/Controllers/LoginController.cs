using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProyectoVet.Models;
using ProyectoVet.Data;

namespace PlataformaFinal.Controllers
{
    public class LoginsController : Controller
    {
        private ProyectoVetContext db = new ProyectoVetContext();

        [HttpGet]
        public ActionResult ValidarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarUsuario(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            /* var user = db.Logins.Where(us => us.Usuario == login.Usuario && us.Pass == login.Pass)
               .FirstOrDefault();*/
            var cliente = db.Clientes.FirstOrDefault(u => u.Documento == login.Documento && u.Password == login.Password);
            if (cliente != null)
            {
                FormsAuthentication.SetAuthCookie(string.Format("{0}|{1}|{2}", cliente.IdCliente, cliente.Nombres, cliente.Documento), false);
                return RedirectToAction("IndexCliente", "Home", new { documento = cliente.IdCliente });
            }
            var medico = db.Medicos.FirstOrDefault(u => u.Documento == login.Documento && u.Password == login.Password);
            if (medico != null)
            {
                FormsAuthentication.SetAuthCookie(string.Format("{0}|{1}|{2}", medico.IdMedico, medico.Nombres, medico.Documento), false);
                return RedirectToAction("IndexMedico", "Home", new { documento = medico.IdMedico });
            }
            var administrador = db.Administradors.FirstOrDefault(u => u.Documento == login.Documento && u.Password == login.Password);
            if (administrador != null)
            {
                FormsAuthentication.SetAuthCookie(string.Format("{0}|{1}", administrador.IdAdministrador, administrador.Nombres), false);
                return RedirectToAction("Index", "Home", new { documento = administrador.IdAdministrador });
            }
            else
            {
                ViewBag.Validar = "Error de validación, verifique documento y/o contraseña";
            }
            return View();
        }

        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("ValidarUsuario");
        }


    }
}