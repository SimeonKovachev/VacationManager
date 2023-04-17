using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VacationManager.Data;
using VacationManager.Entity;
using VacationManager.Enums;

namespace VacationManager.Areas.Dashboard.Controllers
{
    public class VacationsController : Controller
    {
        private VacationContext db = new VacationContext();

        // GET: Dashboard/Vacations
        public async Task<ActionResult> Index()
        {
            return View(await db.Vacations.ToListAsync());
        }

        // GET: Dashboard/Vacations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = await db.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        // GET: Dashboard/Vacations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Vacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,StartDate,EndDate,Type")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Vacations.Add(vacation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vacation);
        }

        // GET: Dashboard/Vacations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = await db.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        // POST: Dashboard/Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,StartDate,EndDate,Type")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vacation);
        }

        // GET: Dashboard/Vacations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = await db.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        // POST: Dashboard/Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vacation vacation = await db.Vacations.FindAsync(id);
            db.Vacations.Remove(vacation);
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
