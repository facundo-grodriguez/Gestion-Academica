using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
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
            Alumno alumnoAEliminar = null;
            foreach (var a in DatosCompartidos.Alumnos)
            {
                if (a.Id == Alumno.Id)
                {
                    alumnoAEliminar = a;
                    break;
                }
            }
            if (alumnoAEliminar != null)
            {
                DatosCompartidos.Alumnos.Remove(alumnoAEliminar);
            }
            return RedirectToPage("Index");
        }
    }
}
