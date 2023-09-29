using EmployeeApi.Dto;
namespace EmployeeApi.Data
{
    public class EmployeeData
    {

        public async Task<List<EmployeeDto>> list()
        {

            try
            {
                return new List<EmployeeDto>();
            }catch (Exception ex)
            {
                throw;
            }

        }
    }
}
