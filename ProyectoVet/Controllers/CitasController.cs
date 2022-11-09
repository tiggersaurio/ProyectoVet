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
    public class CitasController : Controller
    {
        private ProyectoVetContext db = new ProyectoVetContext();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.mascota).Include(c => c.medico);
            return View(citas.ToList());
        }
        public ActionResult IndexCliente()
        {
            var citas = db.Citas.Include(c => c.mascota).Include(c => c.medico);
            return View(citas.ToList());
        }

        public ActionResult IndexMedico()
        {
            var citas = db.Citas.Include(c => c.mascota).Include(c => c.medico);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }
        // GET: Citas/Details/5
        public ActionResult DetailsCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }
        public ActionResult DetailsMedico(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres");
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,IdMedico,IdMascota,Fecha,Hora,Categoria,Consultorio")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("IndexCliente");
            }

            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres", cita.IdMascota);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres", cita.IdMedico);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres", cita.IdMascota);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres", cita.IdMedico);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,IdMedico,IdMascota,Fecha,Hora,Categoria,Consultorio")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres", cita.IdMascota);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres", cita.IdMedico);
            return View(cita);
        }

      
        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Citas.Find(id);
            db.Citas.Remove(cita);
            db.SaveChanges();
            return RedirectToAction("Index");
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
