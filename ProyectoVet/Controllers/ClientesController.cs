using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoVet.Data;
using ProyectoVet.Models;

namespace ProyectoVet.Controllers
{
    public class ClientesController : Controller
    {
        private ProyectoVetContext db = new ProyectoVetContext();
        string Date = DateTime.Now.ToString("yyyy-MM-dd");
        string Hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nombres,Apellidos,Documento,Email,Telefono,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("ValidarUsuario","Logins");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombres,Apellidos,Documento,Email,Telefono,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //FORO
        public ActionResult IndexForo()
        {
            return View(db.Foros.ToList());
        }
        [HttpPost]
        public ActionResult IndexForo(string Nombre)
        {
            var busqueda = from s in db.Foros select s;

            if (!String.IsNullOrEmpty(Nombre))
            {
                busqueda = busqueda.Where(s => s.NombreForo.Contains(Nombre)
                                       || s.Descripcion.Contains(Nombre));
            }
            return View(busqueda.ToList());
        }

        [HttpGet]
        public ActionResult CreateForo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForo(ForoView foro)
        {
            string[] user = User.Identity.Name.Split('|').ToArray();
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var forito = new Foro
                    {
                        NombreForo = foro.NombreForo,
                        Descripcion = foro.Descripcion,
                        Seccion = foro.Seccion,
                        Usuario = user[1],
                        Documento = user[2],
                        Fecha = Date,
                        Hora = Hora,
                    };
                    db.Foros.Add(forito);
                    db.SaveChanges();
                }
                else
                {
                    return View(foro);
                }
            }

            return RedirectToAction("IndexForo");
        }

        [HttpGet]
        public ActionResult DetailsForo(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var casaRutina = db.Aprendices.Find(id);

            Foro foro = db.Foros.Find(id);
            if (foro == null)
            {
                return HttpNotFound();
            }

            var view = new ForoDetailsView
            {
                ForoId = foro.ForoId,
                NombreForo = foro.NombreForo,
                Descripcion = foro.Descripcion,
                Respuestas = foro.respuestas.ToList(),
            };

            return View(view);
        }
        [HttpGet]
        public ActionResult EditForo(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var gimRutina = db.Aprendices.Find(id);
            Foro foro = db.Foros.Find(id);
            if (foro.Equals(null))
            {
                return HttpNotFound();
            }
            return View(foro);
        }
        [HttpPost]
        public ActionResult EditForo(Foro foro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foro).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return View(foro);
            }
            return RedirectToAction("IndexForo");
        }
        public ActionResult DeleteForo(int id)
        {
            var foro = db.Foros.Find(id);
            if (foro != null)
            {
                db.Foros.Remove(foro);
                db.SaveChanges();
            }
            return RedirectToAction("IndexForo");
        }

        [HttpGet]
        public ActionResult CreateRespuesta(int foroId)
        {
            var Respuesta = new RespuestaView
            {
                ForoId = foroId,
            };
            return View(Respuesta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRespuesta(RespuestaView respuestaView)
        {
            string[] user = User.Identity.Name.Split('|').ToArray();
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var Resp = new Respuesta
                    {
                        ForoId = respuestaView.ForoId,
                        RespuestaForo = respuestaView.RespuestaForo,
                        Usuario = user[1],
                        Documento = user[2],
                        Fecha = Date,
                        Hora = Hora,
                    };
                    db.Respuestas.Add(Resp);
                    db.SaveChanges();
                    return RedirectToAction(string.Format("DetailsForo/{0}", respuestaView.ForoId));
                }
            }

            return View(respuestaView);
        }
        public ActionResult EditRespuesta(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var gimRutina = db.Aprendices.Find(id);
            Respuesta respuesta = db.Respuestas.Find(id);
            if (respuesta.Equals(null))
            {
                return HttpNotFound();
            }
            return View(respuesta);
        }
        [HttpPost]
        public ActionResult EditRespuesta(Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return View(respuesta);
            }
            return RedirectToAction(string.Format("DetailsForo/{0}", respuesta.ForoId));
        }
        public ActionResult DeleteRespuesta(int id)
        {
            var respuesta = db.Respuestas.Find(id);
            if (respuesta != null)
            {
                db.Respuestas.Remove(respuesta);
                db.SaveChanges();
            }
            return RedirectToAction(string.Format("DetailsForo/{0}", respuesta.ForoId));
        }
        //FIN FORO

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
