using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TypController : Controller
    {
        private MyDbUserEntities1 db = new MyDbUserEntities1();

        // GET: Typ
        public async Task<ActionResult> Index()
        {
            return View(await db.Typ.ToListAsync());
        }

        // GET: Typ/Details
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typ typ = await db.Typ.FindAsync(id);
            if (typ == null)
            {
                return HttpNotFound();
            }
            return View(typ);
        }

        // GET: Typ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Typ/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nazwa")] Typ typ)
        {
            if (ModelState.IsValid)
            {
                db.Typ.Add(typ);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(typ);
        }

        // GET: Typ/Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typ typ = await db.Typ.FindAsync(id);
            if (typ == null)
            {
                return HttpNotFound();
            }
            return View(typ);
        }

        // POST: Typ/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nazwa")] Typ typ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typ).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(typ);
        }

        // GET: Typ/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typ typ = await db.Typ.FindAsync(id);
            if (typ == null)
            {
                return HttpNotFound();
            }
            return View(typ);
        }

        // POST: Typ/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Typ typ = await db.Typ.FindAsync(id);
            db.Typ.Remove(typ);
            await db.SaveChangesAsync();
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
