using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Dto;
using EmployeeApi.Model;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting.Server;
using Azure;
using EmployeeApi.Data;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {





        [HttpGet]
        
        public async Task<IActionResult> list()
        {
            EmployeeData data = new EmployeeData();
            List<EmployeeDto> list =  new List<EmployeeDto>();
            
            try
            {
                list = await data.list();

                return StatusCode(StatusCodes.Status200OK, new {message = "ok",res = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "error", res = ex });
            }
        }


        /*[HttpGet(":id")]
        [Route("filtre")]
        public IActionResult filtre()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult add()
        {
            return View();
        }*/
    }
}
