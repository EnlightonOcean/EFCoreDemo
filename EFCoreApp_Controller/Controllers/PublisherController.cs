using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFCoreApp_DataAccess.Data;
using EFCoreApp_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCoreApp_Controller.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly DataContext _dataContext;

        public PublisherController(ILogger<PublisherController> logger,DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var publishers = _dataContext.Publishers.ToList();
            return View(publishers);
        }

        public IActionResult Upsert(int? Id)
        {
            var publisher = new Publisher();
            if(Id == null) return View(publisher);
            publisher = _dataContext.Publishers.Find(Id);
            if(publisher == null) return NotFound($"Publisher Id {Id} not found.");
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher publisher)
        {
            if(ModelState.IsValid)
            {
                if(publisher.Id == 0) _dataContext.Publishers.Add(publisher);     
                else _dataContext.Publishers.Update(publisher);    
                if(_dataContext.SaveChanges() > 0 ) return RedirectToAction(nameof(Index)); 
                else return BadRequest() ;
            }
            return View(publisher);
        }

        public IActionResult Delete(int? Id)
        {
            if(Id == null) return NotFound();
            var publisher = _dataContext.Publishers.Find(Id);
            if(publisher == null ) return NotFound($"Publisher Id {Id} not found.");
            _dataContext.Publishers.Remove(publisher);
            if(_dataContext.SaveChanges() >0)
                return RedirectToAction(nameof(Index));
            else    
                return BadRequest();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}