using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WebApp.Models;
using System.Linq;

namespace WebApp.Controllers
{
    public class RaidController : Controller
    {
        private MyDbUserEntities1 db = new MyDbUserEntities1();

        // GET: Raid
        public async Task<ActionResult> Index()
        {
            var raid = db.Raid.Include(r => r.Lokacja).Include(r => r.Typ);
            return View(await raid.ToListAsync());
        }

        // GET: Raid/Details
        public ActionResult Details(int id)
        {
            //  if (id == null)
            //  {
            //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //  }
            //  Raid raid = await db.Raid.FindAsync(id);
            var raid = db.Raid.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // GET: Raid/Create
        public ActionResult Create()
        {
            ViewBag.LokacjaId = new SelectList(db.Lokacja, "Id", "Nazwa");
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa");
            return View();
        }

        // POST: Raid/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nazwa,LokacjaId,TypId")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                db.Raid.Add(raid);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LokacjaId = new SelectList(db.Lokacja, "Id", "Nazwa", raid.LokacjaId);
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa", raid.TypId);
            return View(raid);
        }

        // GET: Raid/Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = await db.Raid.FindAsync(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            ViewBag.LokacjaId = new SelectList(db.Lokacja, "Id", "Nazwa", raid.LokacjaId);
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa", raid.TypId);
            return View(raid);
        }

        // POST: Raid/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nazwa,LokacjaId,TypId")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raid).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LokacjaId = new SelectList(db.Lokacja, "Id", "Nazwa", raid.LokacjaId);
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa", raid.TypId);
            return View(raid);
        }

        // GET: Raid/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = await db.Raid.FindAsync(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // POST: Raid/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Raid raid = await db.Raid.FindAsync(id);
            db.Raid.Remove(raid);
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
