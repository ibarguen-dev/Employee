using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Dto;
using EmployeeApi.Model;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting.Server;
using Azure;
using EmployeeApi.Data;
using Microsoft.AspNetCore.Cors;

namespace EmployeeApi.Controllers
{
    [EnableCors("ReglasCors")]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        public readonly string _sql;
        public EmployeeController(IConfiguration config) {
            _sql = config.GetConnectionString("cadenaConexion");
        }




        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> list()
        {
            EmployeeData data = new EmployeeData(_sql);
            List<EmployeeDto> list =  new List<EmployeeDto>();
            
            try
            {
                list = await data.listEmployee();

                return StatusCode(StatusCodes.Status200OK, new {message = "ok",res = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message, res = list });
            }
        }

        [Route("filtre/{id}")]
        [HttpGet]
        public async Task<IActionResult> filtre(string id)
        {
            EmployeeData data = new EmployeeData(_sql);

            List<EmployeeDto> list = new List<EmployeeDto>();

            try
            {
                list = await data.Employee(id);

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", res = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message, res = list  });
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> add(EmployeeModel oEmployee)
        {
            EmployeeData data = new EmployeeData(_sql);
            bool success = false;
            try
            {
                success = await data.CreateEmployee(oEmployee);
                return StatusCode(StatusCodes.Status201Created, new { message = "creado", res = oEmployee });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message, create = success });
            }
        }
    }
}
