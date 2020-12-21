using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoASP.NET.Models;

namespace ProjetoASP.NET.Controllers
{
    public class fisicasController : Controller
    {
        private aplicacaoEntities db = new aplicacaoEntities();

        // GET: fisicas
        public ActionResult Index()
        {
            var fisica = db.fisica.Include(f => f.cliente);
            return View(fisica.ToList());
        }

        // GET: fisicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fisica fisica = db.fisica.Find(id);
            if (fisica == null)
            {
                return HttpNotFound();
            }
            return View(fisica);
        }

        // GET: fisicas/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome");
            return View();
        }

        // POST: fisicas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rg,cpf,id_cliente")] fisica fisica)
        {
            if (ModelState.IsValid)
            {
                db.fisica.Add(fisica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome", fisica.id_cliente);
            return View(fisica);
        }

        // GET: fisicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fisica fisica = db.fisica.Find(id);
            if (fisica == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome", fisica.id_cliente);
            return View(fisica);
        }

        // POST: fisicas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rg,cpf,id_cliente")] fisica fisica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fisica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome", fisica.id_cliente);
            return View(fisica);
        }

        // GET: fisicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fisica fisica = db.fisica.Find(id);
            if (fisica == null)
            {
                return HttpNotFound();
            }
            return View(fisica);
        }

        // POST: fisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fisica fisica = db.fisica.Find(id);
            db.fisica.Remove(fisica);
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
