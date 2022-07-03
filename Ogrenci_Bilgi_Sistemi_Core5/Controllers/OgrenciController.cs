using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ogrenci_Bilgi_Sistemi_Core5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ogrenci_Bilgi_Sistemi_Core5.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly MyContext _db;

        public OgrenciController(MyContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.MyEntities.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _db.MyEntities.Add(ogrenci);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenci);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = _db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                //return HttpNotFound();
            }
            return View(ogrenci);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = _db.MyEntities.Find(id);
            _db.MyEntities.Remove(ogrenci);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
     

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = _db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                //return HttpNotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ogrenci).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }




    }
}
