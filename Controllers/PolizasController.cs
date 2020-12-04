using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaLafise.Models;

namespace PruebaLafise.Controllers
{
    public class PolizasController : Controller
    {
        private PruebaSegurosEntities db = new PruebaSegurosEntities();

        // GET: Polizas
        public ActionResult Index()
        {
            var poliza = db.Poliza.Include(p => p.Seguro);
            return View(poliza.ToList());
        }

        // GET: Polizas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // GET: Polizas/Create
        public ActionResult Create()
        {
            ViewBag.IdSeguro = new SelectList(db.Seguro, "IdSeguro", "DescripcionSeguro");
            return View();
        }

        // POST: Polizas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPoliza,Cliente,FechaAdquisicion,FechaVencimiento,IdSeguro")] Poliza poliza)
        {
            poliza.FechaAdquisicion = DateTime.Today;
            poliza.FechaVencimiento = DateTime.Today.AddYears(1).AddDays(-1);

            if (ModelState.IsValid)
            {
                db.Poliza.Add(poliza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSeguro = new SelectList(db.Seguro, "IdSeguro", "DescripcionSeguro", poliza.IdSeguro);
            return View(poliza);
        }

        // GET: Polizas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeguro = new SelectList(db.Seguro, "IdSeguro", "DescripcionSeguro", poliza.IdSeguro);
            return View(poliza);
        }

        // POST: Polizas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPoliza,Cliente,FechaAdquisicion,FechaVencimiento,IdSeguro")] Poliza poliza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poliza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeguro = new SelectList(db.Seguro, "IdSeguro", "DescripcionSeguro", poliza.IdSeguro);
            return View(poliza);
        }

        // GET: Polizas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // POST: Polizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poliza poliza = db.Poliza.Find(id);
            db.Poliza.Remove(poliza);
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
