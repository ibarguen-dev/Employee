using EmployeeWeb.Models;
namespace EmployeeWeb.Services
{
    public interface IService_Api
    {
        Task<List<Emploeeys>> list();
        Task<List<Emploeeys>> get(string id);

        Task<bool> add(AgregarEmploeeys empleey);
    }
}
