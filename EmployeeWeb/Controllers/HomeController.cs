using EmployeeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EmployeeWeb.Services;
using System;

namespace EmployeeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService_Api _service;

        public HomeController(IService_Api servicio)
        {
            _service = servicio;
        }

        public async Task<IActionResult> Index(string buscar)
        {

            List<Emploeeys> list;

            if (!String.IsNullOrEmpty(buscar))
            {
                list = await _service.get(buscar);
            }
            else
            {
                list = await _service.list();
            }

            return View(list);
        }

        
        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AgregarEmploeeys model) {

            bool respuesta;
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            respuesta = await _service.add(model);

            if (respuesta)
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