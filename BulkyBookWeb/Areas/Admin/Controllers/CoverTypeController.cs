using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

//Before .net 6 this was procedure to define areas after creating folders based on previlages
//This is not needed anymore but just to be on safe side we can define it
namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CoverTypeController : Controller
{
    private IUnitOfWork _unitOfWork;
    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<CoverType> coverTypes = _unitOfWork.coverType.GetAll();
        return View(coverTypes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.coverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type was created successfully";
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

        var cover = _unitOfWork.coverType.GetFirstOrDefalut(x => x.Id == id);
        //var catList2 = _context.Categories.SingleOrDefault(x=>x.id == id);
        if (cover == null)
            return NotFound();
        return View(cover);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.coverType.Update(obj);
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

        var cover = _unitOfWork.coverType.GetFirstOrDefalut(x => x.Id == id);
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
        var cover = _unitOfWork.coverType.GetFirstOrDefalut(x => x.Id == id);

        if (ModelState.IsValid)
        {
            _unitOfWork.coverType.Remove(cover);
            _unitOfWork.Save();
            TempData["success"] = "Cover type deleted successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
}

