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
    public class HistoriaCsController : Controller
    {
        private ProyectoVetContext db = new ProyectoVetContext();

        // GET: HistoriaCs
        public ActionResult Index()
        {
            var historiaCs = db.HistoriaCs.Include(h => h.mascota).Include(h => h.medico);
            return View(historiaCs.ToList());
        }

        // GET: HistoriaCs/Details/5
        public ActionResult Details(int? id)
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

        // GET: HistoriaCs/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres");
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres");
            return View();
        }

        // POST: HistoriaCs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistoriaId,IdMascota,Edad,Sexo,Especie,Dueno,Correo,Telefono,Ciudad,Dirección,IdMedico,Especialidad,MotivoConsulta,Diagnostico,Observaciones,Recomendaciones,Firma,Fecha")] HistoriaC historiaC)
        {
            if (ModelState.IsValid)
            {
                db.HistoriaCs.Add(historiaC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres", historiaC.IdMascota);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres", historiaC.IdMedico);
            return View(historiaC);
        }

        // GET: HistoriaCs/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres", historiaC.IdMascota);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres", historiaC.IdMedico);
            return View(historiaC);
        }

        // POST: HistoriaCs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistoriaId,IdMascota,Edad,Sexo,Especie,Dueno,Correo,Telefono,Ciudad,Dirección,IdMedico,Especialidad,MotivoConsulta,Diagnostico,Observaciones,Recomendaciones,Firma,Fecha")] HistoriaC historiaC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascotas, "IdMascota", "Nombres", historiaC.IdMascota);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombres", historiaC.IdMedico);
            return View(historiaC);
        }

        // GET: HistoriaCs/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: HistoriaCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoriaC historiaC = db.HistoriaCs.Find(id);
            db.HistoriaCs.Remove(historiaC);
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
