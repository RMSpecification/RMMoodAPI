using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedMood.Models;
using System.Threading.Tasks;

namespace RedMood.Controllers
{
    public class MoodsController : Controller
    {
        private RedMoodContext db = new RedMoodContext();
        private MoodService service = new MoodService();

        // GET: Moods/Increase/5
        public async Task<ActionResult> Increase(int? id)
        {
            return View("index",
                await service.GetMoodsAsync()
            );
        }

        // GET: Moods         
        public async Task<ActionResult> Index()
        {

            return View("index",
                await service.GetMoodsAsync()
            );
        }

        // GET: Moods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moods moods = db.Moods.Find(id);
            if (moods == null)
            {
                return HttpNotFound();
            }
            return View(moods);
        }

        // GET: Moods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Moods moods)
        {
            if (ModelState.IsValid)
            {
                db.Moods.Add(moods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moods);
        }

        // GET: Moods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moods moods = db.Moods.Find(id);
            if (moods == null)
            {
                return HttpNotFound();
            }
            return View(moods);
        }

        // POST: Moods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Moods moods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moods);
        }

        // GET: Moods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moods moods = db.Moods.Find(id);
            if (moods == null)
            {
                return HttpNotFound();
            }
            return View(moods);
        }

        // POST: Moods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moods moods = db.Moods.Find(id);
            db.Moods.Remove(moods);
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
