using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Practical_13_Test2.DataContext;
using MVC_Practical_13_Test2.Models;

namespace MVC_Practical_13_Test2.Controllers
{
    public class DesignationsController : Controller
    {
        private ComanyDbContext db = new ComanyDbContext();

        // GET: Designations
        public async Task<ActionResult> Index()
        {
            return View(await db.Designations.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return View("Error");
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View(new Designation());
        }

        // POST: Designations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Designations")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return View("Error");
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Designations")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(designation);
        }

        // GET: Designations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return View("Error");
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Designation designation = await db.Designations.FindAsync(id);
            db.Designations.Remove(designation);
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
