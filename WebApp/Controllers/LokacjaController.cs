using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LokacjaController : Controller
    {
        private MyDbUserEntities1 db = new MyDbUserEntities1();

        // GET: Lokacja
        public async Task<ActionResult> Index()
        {
            return View(await db.Lokacja.ToListAsync());
        }

        // GET: Lokacja/Details
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokacja lokacja = await db.Lokacja.FindAsync(id);
            if (lokacja == null)
            {
                return HttpNotFound();
            }
            return View(lokacja);
        }

        // GET: Lokacja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokacja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nazwa")] Lokacja lokacja)
        {
            if (ModelState.IsValid)
            {
                db.Lokacja.Add(lokacja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lokacja);
        }

        // GET: Lokacja/Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokacja lokacja = await db.Lokacja.FindAsync(id);
            if (lokacja == null)
            {
                return HttpNotFound();
            }
            return View(lokacja);
        }

        // POST: Lokacja/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nazwa")] Lokacja lokacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokacja).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lokacja);
        }

        // GET: Lokacja/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokacja lokacja = await db.Lokacja.FindAsync(id);
            if (lokacja == null)
            {
                return HttpNotFound();
            }
            return View(lokacja);
        }

        // POST: Lokacja/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lokacja lokacja = await db.Lokacja.FindAsync(id);
            db.Lokacja.Remove(lokacja);
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
