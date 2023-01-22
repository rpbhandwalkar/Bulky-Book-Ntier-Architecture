using BulkyBook.DA;
using BulkyBook.DA.Repository;
using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//Before .net 6 this was procedure to define areas after creating folders based on previlages
//This is not needed anymore but just to be on safe side we can define it
namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> objcategory = _unitOfWork.category.GetAll();
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
        if (ModelState.IsValid)
        {
            _unitOfWork.category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }



    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var catList = _context.Categories.Find(id);

        var catList1 = _unitOfWork.category.GetFirstOrDefalut(x => x.id == id);
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
            _unitOfWork.category.Update(obj);
            _unitOfWork.Save();
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

        var catList = _unitOfWork.category.GetFirstOrDefalut(x => x.id == id);
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
        var catList = _unitOfWork.category.GetFirstOrDefalut(x => x.id == id);

        if (ModelState.IsValid)
        {
            _unitOfWork.category.Remove(catList);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

}
