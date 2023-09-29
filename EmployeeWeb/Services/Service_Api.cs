using EmployeeWeb.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace EmployeeWeb.Services
{
    public class Service_Api: IService_Api
    {
        private readonly string _baseurl;

        public Service_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }


        public async Task<List<Emploeeys>> list()
        {
            List<Emploeeys> result = new List<Emploeeys>();


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Employee/list");

            if (response.IsSuccessStatusCode)
            {
                var json_respuest = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Emploeeys>(json_respuest);
                result.Add(resultado);
            }
            return result;  
        }

        public async Task<List<Emploeeys>> get(string id)
        {
            List<Emploeeys> result = new List<Emploeeys>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"Employee/filtre/{id}");


            if (response.IsSuccessStatusCode)
            {
                var json_respuest = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<Emploeeys>(json_respuest);

                result.Add(resultado);
            }
            return result;
        }

        public async Task<bool> add(AgregarEmploeeys empleey)
        {
            bool res = false;


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(empleey), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"Employee/add",content);

            if(response.IsSuccessStatusCode)
            {
                res = true;
            }

            return res;

        }




    }
}
