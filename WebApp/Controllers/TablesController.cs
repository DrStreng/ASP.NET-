using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WebApp.Models;
using System.Linq;

namespace WebApp.Controllers
{
    public class TablesController : Controller
    {
        private MyDbUserEntities1 db = new MyDbUserEntities1();


        public ActionResult OrderByLogin()
        {
            var user = db.Table.OrderByDescending(a => a.Login).ThenBy(a => a.Id).ToList();
            user.Reverse();
            return View(user);
        }
        public ActionResult OrderByEmail()
        {
            var user = db.Table.OrderByDescending(a => a.Email).ThenBy(a => a.Id).ToList();
            user.Reverse();
            return RedirectToAction("OrderByLogin", user);
        }
        public ActionResult OrderByRole()
        {
            var user = db.Table.OrderByDescending(a => a.Role).ThenBy(a => a.Id).ToList();
            user.Reverse();
            return RedirectToAction("OrderByLogin", user);
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.Table.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = await db.Table.FindAsync(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Login,Email,Password,Role")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Table.Add(table);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(table);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = await db.Table.FindAsync(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Login,Email,Password,Role")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = await db.Table.FindAsync(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Table table = await db.Table.FindAsync(id);
            db.Table.Remove(table);
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
