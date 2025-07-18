using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Carreras
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public required Carrera Carrera { get; set; }
        public IActionResult OnGet(int id)
        {
            var carrera = Servicios.ServiciosCarrera.ObtenerCarreraPorId(id);
            if (carrera == null)
            {
                return RedirectToPage("Index");
            }
            Carrera = carrera;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            ServiciosCarrera.EliminarCarrera(id);
            return RedirectToPage("Index");
        }
    }
}
