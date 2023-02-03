using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//Before .net 6 this was procedure to define areas after creating folders based on previlages
//This is not needed anymore but just to be on safe side we can define it
namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private IUnitOfWork _unitOfWork;
    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> Products = _unitOfWork.product.GetAll();
        return View(Products);
    }

    //Create and update in a single method
    public IActionResult Upsert(int? id)
    {
        Product product = new();
        //To create dropdown select list
        IEnumerable<SelectListItem> CategoryList = _unitOfWork.category.GetAll().Select(
        x => new SelectListItem
        {
            Text = x.Name,
            Value = x.id.ToString()
        });
        //To create dropdown select list
        IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.coverType.GetAll().Select(
        x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });

        if (id == null || id == 0)
        {
            ViewBag.CategoryList = CategoryList;
            ViewBag.CoverTypeList = CoverTypeList;
            //Create product
            return View(product);
        }
        else
        {
            //Update user
        }
        //var catList = _context.Categories.Find(id);

        //var cover = _unitOfWork.product.GetFirstOrDefalut(x => x.Id == id);
        ////var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
        //if (cover == null)
        //    return NotFound();
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Product obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.product.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "cover Type updated successfully";
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

        var cover = _unitOfWork.product.GetFirstOrDefalut(x => x.Id == id);
        //var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
        if (cover == null)
            return NotFound();
        return View(cover);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletPost(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var cover = _unitOfWork.product.GetFirstOrDefalut(x => x.Id == id);

        if (ModelState.IsValid)
        {
            _unitOfWork.product.Remove(cover);
            _unitOfWork.Save();
            TempData["success"] = "Cover type deleted successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
}

