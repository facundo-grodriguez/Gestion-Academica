using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public required Alumno Alumno { get; set; }
        public void OnGet(int id)
        {
            foreach (var a in DatosCompartidos.Alumnos)
            {
                if (a.Id == id)
                {
                    Alumno = a;
                    break;
                }
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var a in DatosCompartidos.Alumnos)
            {
                if (a.Id == Alumno.Id)
                {
                    a.Nombre = Alumno.Nombre;
                    a.Apellido = Alumno.Apellido;
                    a.DNI = Alumno.DNI;
                    a.Email = Alumno.Email;
                    a.FechaNacimiento = Alumno.FechaNacimiento;
                    break;
                }
            }
            return RedirectToPage("Index");
        }
    }
}
