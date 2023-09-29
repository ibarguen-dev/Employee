namespace EmployeeApi.Dto
{
    public class EmployeeDto
    {
        public int IdEmployee { get; set; }

        public int Documento { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public string Genero { get; set; }
    }
}
