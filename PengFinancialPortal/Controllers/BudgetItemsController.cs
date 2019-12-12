using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PengFinancialPortal.Models;

namespace PengFinancialPortal.Controllers
{
    public class BudgetItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetItems
        public ActionResult Index()
        {
            return View(db.BudgetItems.ToList());
        }

        // GET: BudgetItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            return View(budgetItems);
        }

        // GET: BudgetItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created,Name,TargetAmount,CurrentAmount")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                db.BudgetItems.Add(budgetItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetItems);
        }

        // GET: BudgetItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            return View(budgetItems);
        }

        // POST: BudgetItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Name,TargetAmount,CurrentAmount")] BudgetItems budgetItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budgetItems);
        }

        // GET: BudgetItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            if (budgetItems == null)
            {
                return HttpNotFound();
            }
            return View(budgetItems);
        }

        // POST: BudgetItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetItems budgetItems = db.BudgetItems.Find(id);
            db.BudgetItems.Remove(budgetItems);
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
