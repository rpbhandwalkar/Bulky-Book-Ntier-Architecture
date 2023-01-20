using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objcategory = _context.Categories;    
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
                _context.Categories.Add(obj);
                _context.SaveChanges();
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
            var catList = _context.Categories.Find(id);
            if (catList == null)
                return NotFound();
            //var catList1 = _context.Categories.FirstOrDefault(x=>x.id == id);
            //var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
            return View(catList);
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
                _context.Categories.Update(obj);
                _context.SaveChanges();
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
            var catList = _context.Categories.Find(id);
            if (catList == null)
                return NotFound();
            //var catList1 = _context.Categories.FirstOrDefault(x=>x.id == id);
            //var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
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
            var catList = _context.Categories.Find(id);

            if (ModelState.IsValid)
            {
                _context.Categories.Remove(catList);
                _context.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
