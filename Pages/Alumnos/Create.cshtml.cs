using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public required Alumno Alumno { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Alumno.Id = DatosCompartidos.ObtenerNuevoIdAlumnos();
            DatosCompartidos.Alumnos.Add(Alumno);
            return RedirectToPage("Index");
        }
    }
}
