using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        public List<Alumno> Alumnos { get; set; }
        public void OnGet()
        {
            Alumnos = DatosCompartidos.Alumnos;
        }
    }
}
