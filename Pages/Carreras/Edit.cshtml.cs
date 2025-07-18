using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Servicios;
    
namespace SistemaAcademico.Pages.Carreras
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public required Carrera Carrera { get; set; }
        public List<string> Modalities { get; set; } = Helpers.OpcionesModalidad.List;

        public void OnGet(int id)
        {
            Modalities = OpcionesModalidad.List;

            Carrera? carrera = Servicios.ServiciosCarrera.ObtenerCarreraPorId(id);
            if (carrera != null)
            {
                Carrera = carrera;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Carrera no encontrada.");
            }
        }
        public IActionResult OnPost()
        {
            Modalities = OpcionesModalidad.List;

            ServiciosCarrera.EditarCarrera(Carrera);

            return RedirectToPage("Index");
        }
    }
}
