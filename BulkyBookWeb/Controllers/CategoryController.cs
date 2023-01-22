using BulkyBook.DA;
using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _context;
        public CategoryController(ICategoryRepository context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objcategory = _context.GetAll();    
            return View(objcategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DIsplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The display order should not be same as name.");
            }
            if (ModelState.IsValid) { 
                _context.Add(obj);
                _context.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            //var catList = _context.Categories.Find(id);

            var catList1 = _context.GetFirstOrDefalut(x=>x.id == id);
            //var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
            if (catList1 == null)
                return NotFound();
            return View(catList1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DIsplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The display order should not be same as name.");
            }
            if (ModelState.IsValid)
            {
                _context.Update(obj);
                _context.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var catList = _context.Categories.Find(id);
           
            var catList = _context.GetFirstOrDefalut(x=>x.id == id);
            //var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
            if (catList == null)
                return NotFound();
            return View(catList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catList = _context.GetFirstOrDefalut(x => x.id == id);

            if (ModelState.IsValid)
            {
                _context.Remove(catList);
                _context.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
