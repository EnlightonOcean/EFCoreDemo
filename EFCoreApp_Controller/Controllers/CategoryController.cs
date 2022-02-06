using System.Diagnostics;
using EFCoreApp_DataAccess.Data;
using EFCoreApp_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCoreApp_Controller.Controllers;
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly DataContext _dataContext;

    public CategoryController(ILogger<CategoryController> logger,DataContext dataContext)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    [Route("Category/CreateMultiple/{count}")]
    public IActionResult CreateMultiple(int? count)
    {
        IList<Category>  categoryList = new List<Category>();
        for (int i = 0; i < count; i++)
        {
            categoryList.Add(new Category{Name = Guid.NewGuid().ToString()});
        }
        _dataContext.Categories.AddRange(categoryList);
        if(_dataContext.SaveChanges()>0)
            return RedirectToAction(nameof(Index));
        else
        {
            return BadRequest();
        }
    }

    public IActionResult Index()
    {
        var categories = _dataContext.Categories.ToList();
        return View(categories);
    }

    public IActionResult Delete(int? Id)
    {
        if(Id == null) return NotFound();//($"Category Id {Id} not found.");
        var category = _dataContext.Categories.Find(Id);
        if(category == null ) return NotFound($"Category Id {Id} not found.");
        _dataContext.Categories.Remove(category);
        if(_dataContext.SaveChanges() >0)
            return RedirectToAction(nameof(Index));
        else    
            return BadRequest();
    }

    public IActionResult Upsert(int? Id)
    {
        var category = new Category();
        if(Id == null) return View(category);
        category = _dataContext.Categories.Find(Id);
        if(category == null) return NotFound($"Category Id {Id} not found.");
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Category category)
    {
       if(ModelState.IsValid){
           if(category.Id == 0)
           {
               _dataContext.Categories.Add(category);
           }
           else
           {
                _dataContext.Categories.Update(category);
           }
           if(_dataContext.SaveChanges() > 0)
           {
               return RedirectToAction(nameof(Index));
           }
        }
        return View(category);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
