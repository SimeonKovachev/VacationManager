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

namespace VacationManager.Areas.Dashboard.Controllers
{
    public class LeadersController : Controller
    {
        private VacationContext db = new VacationContext();

        // GET: Dashboard/Leaders
        public async Task<ActionResult> Index()
        {
            return View(await db.Leaders.ToListAsync());
        }

        // GET: Dashboard/Leaders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leader leader = await db.Leaders.FindAsync(id);
            if (leader == null)
            {
                return HttpNotFound();
            }
            return View(leader);
        }

        // GET: Dashboard/Leaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Leaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FullName,Age,Profession")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                db.Leaders.Add(leader);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(leader);
        }

        // GET: Dashboard/Leaders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leader leader = await db.Leaders.FindAsync(id);
            if (leader == null)
            {
                return HttpNotFound();
            }
            return View(leader);
        }

        // POST: Dashboard/Leaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FullName,Age,Profession")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leader).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(leader);
        }

        // GET: Dashboard/Leaders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leader leader = await db.Leaders.FindAsync(id);
            if (leader == null)
            {
                return HttpNotFound();
            }
            return View(leader);
        }

        // POST: Dashboard/Leaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Leader leader = await db.Leaders.FindAsync(id);
            db.Leaders.Remove(leader);
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
