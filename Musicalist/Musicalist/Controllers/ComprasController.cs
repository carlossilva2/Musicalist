using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Musicalist.Models;

namespace Musicalist.Controllers
{
    public class ComprasController : Controller
    {
        private appDB db = new appDB();

        // GET: Compras
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.User);
            return View(compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.UserFK = new SelectList(db.User, "UserID", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComprasID,Conteudo,DataCompra,RuaEntreg,CidadeEntreg,PostalEntreg,PaisEntreg,EntregEFatur,RuaFatur,CidadeFatur,PostalFatur,PaisFatur,UserFK")] Compras compras)
        {
           /* try
            {
                if (compras.EntregEFatur)
                {
                    compras.PaisFatur = compras.PaisFatur;
                    compras.RuaFatur = compras.RuaEntreg;
                    compras.PostalFatur = compras.PostalEntreg;
                    compras.CidadeFatur = compras.CidadeEntreg;
                }
                else
                {
                    compras.PaisFatur = "";
                    compras.RuaFatur = "";
                    compras.PostalFatur = "";
                    compras.CidadeFatur = "";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("An error as occured {0}", ex.Message));
                throw;
            }*/
            
            int novoID = 0;
            try
            {
                novoID = db.Compras.Max(d => d.ComprasID) + 1;
            }
            catch (Exception)
            {
                novoID = 1;
                throw;
            }


            compras.ComprasID = novoID;
            if (ModelState.IsValid)
            {
                db.Compras.Add(compras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserFK = new SelectList(db.User, "UserID", "Nome", compras.UserFK);
            return View(compras);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserFK = new SelectList(db.User, "UserID", "Nome", compras.UserFK);
            return View(compras);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComprasID,Conteudo,DataCompra,RuaEntreg,CidadeEntreg,PostalEntreg,PaisEntreg,EntregEFatur,RuaFatur,CidadeFatur,PostalFatur,PaisFatur,UserFK")] Compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserFK = new SelectList(db.User, "UserID", "Nome", compras.UserFK);
            return View(compras);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compras compras = db.Compras.Find(id);
            db.Compras.Remove(compras);
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
