using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class ServiceController(ServiceManager _serviceManager) : Controller
    {
        public IActionResult Index()
        {
            
            var list = _serviceManager.GetAll(1);

            return View(list);
        }
        [HttpGet]
        public IActionResult New()

        {
            return View();
        }

        [HttpPost]
        public IActionResult New(ServiceVM model)
        {
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.UserId = 1;
            var response = _serviceManager.New(model);

            if (response > 0) return RedirectToAction("Index");

            ViewBag.message = "Error, we couldn't add your service";
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)

        {
            var model = _serviceManager.GetServiceById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ServiceVM model) 

        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = _serviceManager.Edit(model);
            if (response > 0) return RedirectToAction("Index");
            ViewBag.message = "Error, we couldn't add your service";

            return View();
        }

      
        public IActionResult Delete(int id)

        {
            var response = _serviceManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}