using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coop.Models;

namespace Coop.Controllers
{
    public class AssortmentController : Controller
    {

        protected DataContext db = new DataContext();
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Views()
        {
            var items = db.GetAllAssortments();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assortment assortment)
        {
            if (assortment != null)
            {
                db.Assortments.Add(assortment);
                db.SaveChanges();
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var item = db.FindAssortmentById(id);
            return View(item);
           
        }
        [HttpPost]
        public IActionResult Delete(Assortment assortment)
        {
            db.Assortments.Remove(assortment);
            db.SaveChanges();
            return RedirectToAction("Views");
        }
    }
}
