using System.ComponentModel.DataAnnotations;


namespace SistemaAcademico.Models
{
    public class Alumno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe agregar nombre/s")]
        [StringLength(50, ErrorMessage = "No puede superar los 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debe agregar apellido/s")]
        [StringLength(50, ErrorMessage = "No puede superar los 50 caracteres")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Debe agregar el DNI")]
        [Range(1000000, 99999999, ErrorMessage = "El DNI debe tener entre 7 y 8 dígitos")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "Debe agregar un email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Agregue fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
