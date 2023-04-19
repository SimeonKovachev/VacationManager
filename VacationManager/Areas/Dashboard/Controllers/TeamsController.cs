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
    public class TeamsController : Controller
    {
        private VacationContext db = new VacationContext();

        // GET: Dashboard/Teams
        public async Task<ActionResult> Index()
        {
            var teams = db.Teams.Include(t => t.Leader).Include(t => t.Project).Include(t => t.Worker);
            return View(await teams.ToListAsync());
        }

        // GET: Dashboard/Teams/Create
        public ActionResult Create()
        {
            ViewBag.LeaderID = new SelectList(db.Leaders, "ID", "FullName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name");
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,ProjectID,LeaderID,WorkerID,NumOfWorkers")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LeaderID = new SelectList(db.Leaders, "ID", "FullName", team.LeaderID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", team.ProjectID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FullName", team.WorkerID);
            return View(team);
        }

        // GET: Dashboard/Teams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeaderID = new SelectList(db.Leaders, "ID", "FullName", team.LeaderID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", team.ProjectID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FullName", team.WorkerID);
            return View(team);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,ProjectID,LeaderID,WorkerID,NumOfWorkers")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LeaderID = new SelectList(db.Leaders, "ID", "FullName", team.LeaderID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", team.ProjectID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FullName", team.WorkerID);
            return View(team);
        }

        // GET: Dashboard/Teams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Dashboard/Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            db.Teams.Remove(team);
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
