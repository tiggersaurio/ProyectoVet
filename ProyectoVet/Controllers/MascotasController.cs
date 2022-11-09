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
using Rotativa;

namespace ProyectoVet.Controllers
{
    public class MascotasController : Controller
    {
        private ProyectoVetContext db = new ProyectoVetContext();
        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotas = db.Mascotas.Include(m => m.cliente);
            return View(mascotas.ToList());
        }

        public ActionResult IndexCliente()
        {
            var mascotas = db.Mascotas.Include(m => m.cliente);
            return View(mascotas.ToList());
        }

        public ActionResult IndexMedico()
        {
            var mascotas = db.Mascotas.Include(m => m.cliente);
            return View(mascotas.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var mascota = db.Aprendices.Find(id);

            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }

            var view = new MascotaDetailsView
            {
                IdMascota = mascota.IdMascota,
                Nombres = mascota.Nombres,
                Especie = mascota.Especie,
                Edad = mascota.Edad,
                Especificaciones = mascota.Especificaciones,
                HistoriaCs = mascota.historiaCs.ToList(),
            };

            return View(view);
        }

        public ActionResult DetailsHistoria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaC historia = db.HistoriaCs.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }
        public ActionResult DetailsCliente(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var mascota = db.Aprendices.Find(id);

            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }

            var view = new MascotaDetailsView
            {
                IdMascota = mascota.IdMascota,
                Nombres = mascota.Nombres,
                Especie = mascota.Especie,
                Edad = mascota.Edad,
                Especificaciones = mascota.Especificaciones,
                HistoriaCs = mascota.historiaCs.ToList(),
            };

            return View(view);
        }

        public ActionResult DetailsMedico(int? id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var mascota = db.Aprendices.Find(id);

            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }

            var view = new MascotaDetailsView
            {
                IdMascota = mascota.IdMascota,
                Nombres = mascota.Nombres,
                Especie = mascota.Especie,
                Edad = mascota.Edad,
                Especificaciones = mascota.Especificaciones,
                HistoriaCs = mascota.historiaCs.ToList(),
            };

            return View(view);
        }


        // GET: Mascotas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres");
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMascota,Nombres,Especie,Edad,Especificaciones,IdCliente")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", mascota.IdCliente);
            return View(mascota);
        }

        public ActionResult CreateCliente()
        {
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(Mascota mascota)
        {
            string[] user = User.Identity.Name.Split('|').ToArray();
            if (ModelState.IsValid)
            {
                var mas = new Mascota
                {
                    IdMascota = mascota.IdMascota,
                    Nombres = mascota.Nombres,
                    Edad = mascota.Edad,
                    Especie = mascota.Especie,
                    Especificaciones = mascota.Especificaciones,
                    IdCliente = Convert.ToInt32(user[0])
                };
                db.Mascotas.Add(mas);
                db.SaveChanges();
                return RedirectToAction("IndexCliente");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", mascota.IdCliente);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", mascota.IdCliente);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMascota,Nombres,Especie,Edad,Especificaciones,IdCliente")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", mascota.IdCliente);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ImprimirHistoriaView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaC historiaC = db.HistoriaCs.Find(id);
            if (historiaC == null)
            {
                return HttpNotFound();
            }
            return View(historiaC);
        }

        public ActionResult ImprimirHistoria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaC historiaC = db.HistoriaCs.Find(id);
            if (historiaC == null)
            {
                return HttpNotFound();
            }
            return new ActionAsPdf(string.Format("ImprimirHistoriaView/{0}", historiaC.HistoriaId)) { FileName = "HistoriaClinica.pdf" };
        }

        public ActionResult ImprimirCarneView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        public ActionResult ImprimirCarne(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return new ActionAsPdf(string.Format("ImprimirCarneView/{0}", mascota.IdMascota)) { FileName = "Carne.pdf" };
        }
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
