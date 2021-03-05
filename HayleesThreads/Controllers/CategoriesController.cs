using Microsoft.AspNetCore.Mvc;
using HayleesThreads.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HayleesThreads.Controllers
{
  
  public class CategoriesController : Controller
  {
    private readonly HayleesThreadsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public CategoriesController(UserManager<ApplicationUser> userManager, HayleesThreadsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }
    public ActionResult Details(int id)
    {
      var thisCategory = _db.Categories
          .Include(category => category.JoinTables)
          .ThenInclude(join => join.Product)
          .FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult AddProduct(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
      ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "ProductName");
      return View(thisCategory);
    }
    [HttpPost]
    public ActionResult AddProduct(Category category, int ProductId)
    {
      
      if (ProductId != 0 )
      {
        _db.CategoryProduct.Add(new CategoryProduct() { ProductId = ProductId, CategoryId = category.CategoryId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteProduct(int joinId)
    {
      var joinEntry = _db.CategoryProduct.FirstOrDefault(entry => entry.CategoryProductId == joinId);
      _db.CategoryProduct.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}