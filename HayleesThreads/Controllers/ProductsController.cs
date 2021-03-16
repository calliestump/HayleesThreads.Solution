using Microsoft.AspNetCore.Mvc;
using HayleesThreads.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;

namespace HayleesThreads.Controllers
{
  
  public class ProductsController : Controller
  {
    private readonly HayleesThreadsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public ProductsController(UserManager<ApplicationUser> userManager, HayleesThreadsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Product> model = _db.Products.ToList();
      return View(model);
    }

    // [HttpGet("/NewsLetter")]
    // public ActionResult NewsLetter()
    // {
    //   return View();
    // }
    public ActionResult Details(int id)
    {
      var thisProduct = _db.Products
          .Include(product => product.JoinTables)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Product product)
    {
      _db.Products.Add(product);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
      _db.Entry(product).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      _db.Products.Remove(thisProduct);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult AddCategory(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(products => products.ProductId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "CategoryName");
      return View(thisProduct);
    }
    [HttpPost]
    public ActionResult AddCategory(Product product, int CategoryId)
    {
      if (CategoryId != 0 )
      {
        _db.CategoryProduct.Add(new CategoryProduct() { CategoryId = CategoryId, ProductId = product.ProductId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public ActionResult DeleteCategory(int joinId)
    {
      var joinEntry = _db.CategoryProduct.FirstOrDefault(entry => entry.CategoryProductId == joinId);
      _db.CategoryProduct.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
} 