using EmployeeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EmployeeWeb.Services;
namespace EmployeeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService_Api _service;

        public HomeController(IService_Api servicio)
        {
            _service = servicio;
        }

        public async Task<IActionResult> Index()
        {
            List<Emploeeys> list;
            list = await _service.list();
            /*if (id == "")
            {
                
            }
            else
            {
                /*list = await _service.get(id);
            }*/
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AgregarEmploeeys model) {

            bool res = await _service.add(model);

            if (res)
            {
               return RedirectToAction("index");
            }
            else
            {
                return NoContent();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}