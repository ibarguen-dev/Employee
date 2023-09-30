using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace EmployeeWeb.Models
{
    public class AgregarEmploeeys
    {
        [Required (ErrorMessage = "No dejar el campo del nombre vacio"), RegularExpression("/^[a-zA-ZÁáÉéÍíÓóÚúÜüÑñ\\s]+$/")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "No dejar el campo del apellido vacio"), RegularExpression("/^[a-zA-ZÁáÉéÍíÓóÚúÜüÑñ\\s]+$/")]
        public string apellido { get; set; }

        [Required, RegularExpression("[0-9]+", ErrorMessage = "Solo se pueden ingresar numeros")]
        public int documento { get; set; }

        [Required, RegularExpression("[0-9]+", ErrorMessage = "Solo se pueden ingresar numeros")]
        public string telefono { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el email no es correcto")]
        public string correo { get; set; }

        [Required]
        public string direccion { get; set; }

        [Required, MaxLength(1)]
        public string genero { get; set; }
    }
}
