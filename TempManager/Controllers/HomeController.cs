using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class HomeController : Controller
    {
        private TempManagerContext data { get; set; }
        public HomeController(TempManagerContext ctx) => data = ctx;

        public ViewResult Index()
        {
            var temps = data.Temps.OrderBy(t => t.Date).ToList();
            return View(temps);
        }

        [HttpGet]
        public ViewResult Add() => View(new Temp());

        [HttpPost]
        public IActionResult Add(Temp temp)
        {
            if (temp.Date.HasValue)
            {
                bool dateExists = data.Temps.Any(t => t.Date.HasValue && t.Date.Value.Date == temp.Date.Value.Date);

                if (dateExists)
                {
                    ModelState.AddModelError("Date", "This date has already been logged in the system");
                }
                
            }
            if (ModelState.IsValid)
            { 
                data.Temps.Add(temp);
               data.SaveChanges();
              

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("" ,"Please correct all errors");
                return View(temp);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var temp = data.Temps.Find(id);
            return View(temp);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Temp temp)
        {
            data.Remove(temp);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}