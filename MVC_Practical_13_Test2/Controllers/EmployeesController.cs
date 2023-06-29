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
using MVC_Practical_13_Test2.ViewModel;

namespace MVC_Practical_13_Test2.Controllers
{
    public class EmployeesController : Controller
    {
        private ComanyDbContext db = new ComanyDbContext();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.Designations);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var employees = await db.Employees.Include(e => e.Designations).ToListAsync();
            var emp = employees.ToList().Find(i => i.Id == id);
            if (emp == null)
            {
                return View("Error");
            }
            return View(emp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designations");
            return View(new Employee());
        }

        // POST: Employees/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,PhoneNumber,Address,Salary,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designations", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var employees = await db.Employees.Include(e => e.Designations).ToListAsync();
            var emp = employees.ToList().Find(i => i.Id == id);
            if (emp == null)
            {
                return View("Error");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designations", emp.DesignationId);
            return View(emp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,PhoneNumber,Address,Salary,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Designations", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var employees = await db.Employees.Include(e => e.Designations).ToListAsync();
            var emp =  employees.ToList().Find(i=> i.Id == id);
            ;
            if (emp == null)
            {
                return View("Error");
            }
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Linq1()
        {
            List<EmpDesg> employee = await db.Employees.Join(db.Designations,emp=> emp.DesignationId,desg=> desg.Id,(emp,desg)=> new { emp, desg }).Select((e)=> new EmpDesg(){Emp = e.emp,Desg = e.desg}).ToListAsync();
            return View(employee);
        }

        public async Task<ActionResult> Linq2()
        {
            var employee = await db.Employees.Join(db.Designations, emp => emp.DesignationId, desg => desg.Id, (emp, desg) => new { emp, desg }).GroupBy(x=> x.desg.Designations ).Select(s => new EmpCountByDesg() { Degination = s.Key , EmpCount = s.Count()}).ToListAsync();
            return View(employee);
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
