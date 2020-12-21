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
    public class juridicasController : Controller
    {
        private aplicacaoEntities db = new aplicacaoEntities();

        // GET: juridicas
        public ActionResult Index()
        {
            var juridica = db.juridica.Include(j => j.cliente);
            return View(juridica.ToList());
        }

        // GET: juridicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juridica juridica = db.juridica.Find(id);
            if (juridica == null)
            {
                return HttpNotFound();
            }
            return View(juridica);
        }

        // GET: juridicas/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome");
            return View();
        }

        // POST: juridicas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cnpj,id_cliente")] juridica juridica)
        {
            if (ModelState.IsValid)
            {
                db.juridica.Add(juridica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome", juridica.id_cliente);
            return View(juridica);
        }

        // GET: juridicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juridica juridica = db.juridica.Find(id);
            if (juridica == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome", juridica.id_cliente);
            return View(juridica);
        }

        // POST: juridicas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cnpj,id_cliente")] juridica juridica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juridica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "nome", juridica.id_cliente);
            return View(juridica);
        }

        // GET: juridicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juridica juridica = db.juridica.Find(id);
            if (juridica == null)
            {
                return HttpNotFound();
            }
            return View(juridica);
        }

        // POST: juridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            juridica juridica = db.juridica.Find(id);
            db.juridica.Remove(juridica);
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
