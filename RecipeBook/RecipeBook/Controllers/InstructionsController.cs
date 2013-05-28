using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class InstructionsController : Controller
    {
        private InstructionDBContext db = new InstructionDBContext();

        //
        // GET: /Instructions/

        public ActionResult Index()
        {
            return View(db.Instructions.ToList());
        }

        //
        // GET: /Instructions/Details/5

        public ActionResult Details(int id = 0)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }
            return View(instruction);
        }

        //
        // GET: /Instructions/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Instructions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                db.Instructions.Add(instruction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instruction);
        }

        //
        // GET: /Instructions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }
            return View(instruction);
        }

        //
        // POST: /Instructions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instruction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instruction);
        }

        //
        // GET: /Instructions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }
            return View(instruction);
        }

        //
        // POST: /Instructions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instruction instruction = db.Instructions.Find(id);
            db.Instructions.Remove(instruction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}