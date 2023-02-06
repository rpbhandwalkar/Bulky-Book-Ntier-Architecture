using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//Before .net 6 this was procedure to define areas after creating folders based on previlages
//This is not needed anymore but just to be on safe side we can define it
namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;   
    }

    public IActionResult Index()
    {
        IEnumerable<Product> Products = _unitOfWork.product.GetAll();
        return View(Products);
    }

    //Create and update in a single method
    public IActionResult Upsert(int? id)
    {
        //To create select list for category list and cover type list
        ProductVM productVM = new()
        {
            product = new(),
            categoryList = _unitOfWork.category.GetAll().Select(
           x => new SelectListItem
           {
               Text = x.Name,
               Value = x.id.ToString()
           }),
            coverTypeList = _unitOfWork.coverType.GetAll().Select(
           x => new SelectListItem
           {
               Text = x.Name,
               Value = x.Id.ToString()
           }),
        };

        if (id == null || id == 0)
        {
            //ViewBag.CategoryList = CategoryList;
            //ViewBag.CoverTypeList = CoverTypeList;
            //Create product
            return View(productVM);
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
        return View(productVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVM obj, IFormFile file)
    {

        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file!=null)
            {
                string fileName = Guid.NewGuid().ToString();
                var upload = Path.Combine(wwwRootPath, @"images\products");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create)) { 
                    file.CopyTo(fileStreams);
                }
                obj.product.ImageUrl = @"\images\products\" + fileName + extension;

            }
            _unitOfWork.product.Add(obj.product);
            _unitOfWork.Save();
            TempData["success"] = "cover Type updated successfully";
            //return RedirectToAction("Index");
        }
        return View(obj);
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

