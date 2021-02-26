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
  }
}