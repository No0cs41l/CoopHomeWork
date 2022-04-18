using Coop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Coop.Controllers
{
    public class ProductController : Controller
    {
        protected DataContext db = new DataContext();
        
        public IActionResult Index()
        {
            var items = db.GetAllProducts();
            return View(items);
        }

        public IActionResult EditProduct(int id)
        {
            var item = db.FindProductById(id);
            if (item == null)
            {
                return RedirectToAction("Views");
            }

            var item2 = new SelectList(db.GetAllAssortiment(), "Id", "Name");

            ViewData["AssortmentId1"] = item2;
            return View(item);
        }


        [HttpPost]
        public IActionResult EditProduct(Product p, AssortimentProduct asp, int AssortmentId1, int iad)
        {
       
            var item = new AssortimentProduct { ProductId = p.Id, AssortmentId = AssortmentId1 };
            db.AssortimentProducts.Add(item);
            db.SaveChanges();

            if (ModelState.IsValid)
            {
                db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }



            return RedirectToAction("Views");
        }

        public IActionResult Create()
        {
            
            var item = new SelectList(db.GetAllAssortiment(), "Id", "Name");

            ViewData["AssortmentId1"] = item;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p, int AssortmentId1)
        {


           if(p.Name != null)
           { 
                db.Products.Add(p);
                db.SaveChanges();
                var item = db.Products.Where(x => x.Name == p.Name).Select(x=>x).First();
                var asp = new AssortimentProduct { AssortmentId = AssortmentId1, ProductId = item.Id };
                db.AssortimentProducts.Add(asp);
                db.SaveChanges();
                return RedirectToAction("Create");
                
                
           }
                
            return View();
        }

        public IActionResult Views()
        {
            var items = db.GetAllAssortimentProduct();
            foreach (var item in items)
            {
                var a = item.Product.AssortimentProducts;
            }
            return View(items);
        }


        public IActionResult Edit(int id)
        {   
            
            var item = db.GetAllProducts111(id);
            if (item == null)
            {
                return RedirectToAction("Views");
            }

            var item2 = new SelectList(db.GetAllAssortiment(),"Id","Name", item.AssortmentId);
           
            ViewData["AssortmentId1"] = item2;
            ViewData["iad"] = item.AssortmentId;

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Product p,AssortimentProduct asp, int AssortmentId1, int iad)
        {

            asp.ProductId = p.Id;
            asp.AssortmentId = iad;
            asp.Product = null;
            db.AssortimentProducts.Remove(asp);
            db.SaveChanges();
            var item = new AssortimentProduct { ProductId = p.Id, AssortmentId = AssortmentId1 };
            db.AssortimentProducts.Add(item);
            db.SaveChanges();





            if (ModelState.IsValid)
            {
                db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
           


            return RedirectToAction("Views");
        }

        public IActionResult Delete(int id)
        {
            var item = db.FindProductById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Views");
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
