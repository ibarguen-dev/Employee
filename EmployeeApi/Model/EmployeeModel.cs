using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class EmployeeModel
    {
        [Required (ErrorMessage = "No dejar el campo del Nombre vacio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "No dejar el campo del Apellido vacio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "No dejar el campo del Documento vacio")]
        public int Documento { get; set; }
        [Required(ErrorMessage = "No dejar el campo del Telefono vacio")]
        public string Telefono { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el email no es correcto")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "No dejar el campo del Dirccion vacio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "No dejar el campo del Genero vacio")]
        public string Genero { get; set; }
    }
}
