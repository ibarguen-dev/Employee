using EmployeeApi.Dto;
using EmployeeApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;
namespace EmployeeApi.Data
{
    public class EmployeeData
    {
        private readonly string cadenaSql;

        public EmployeeData(string conexion)
        {
            cadenaSql = conexion;
        }

        public async Task<List<EmployeeDto>> listEmployee()
        {
            List<EmployeeDto> employeesData = new List<EmployeeDto>();
            try
            {
                await using(var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_busqueda",conexion);
                    cmd.Parameters.AddWithValue("value", "");
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd  = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            employeesData.Add(new EmployeeDto
                            {

                                employeeId = Convert.ToInt32(rd["employeeId"]),
                                Documento = Convert.ToInt32(rd["Documento"]),
                                Nombre = rd["Nombre"].ToString(),
                                Apellido = rd["Apellido"].ToString(),
                                Correo = rd["Correo"].ToString(),
                                Telefono = rd["Telefono"].ToString(),
                                Direccion = rd["Direccion"].ToString(),
                                Genero = rd["Genero"].ToString()
                            });
                        }
                    }
                }


                return employeesData;


            }catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<List<EmployeeDto>> Employee(string id)
        {
            List<EmployeeDto> employeesData = new List<EmployeeDto>();
            try
            {
                await using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_busqueda", conexion);
                    cmd.Parameters.AddWithValue("value", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            employeesData.Add(new EmployeeDto
                            {

                                employeeId = Convert.ToInt32(rd["employeeId"]),
                                Documento = Convert.ToInt32(rd["Documento"]),
                                Nombre = rd["Nombre"].ToString(),
                                Apellido = rd["Apellido"].ToString(),
                                Correo = rd["Correo"].ToString(),
                                Telefono = rd["Telefono"].ToString(),
                                Direccion = rd["Direccion"].ToString(),
                                Genero = rd["Genero"].ToString()
                            });
                        }
                    }
                }


                return employeesData;


            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> CreateEmployee(EmployeeModel model) {

            bool res;
            try
            {
                await using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_crear", conexion);
                    cmd.Parameters.AddWithValue("Documento", model.Documento);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", model.Apellido);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", model.Direccion);
                    cmd.Parameters.AddWithValue("Genero", model.Genero);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

            }catch(Exception ex)
            {
                throw;
            }

            return true;


        }
    }
}
