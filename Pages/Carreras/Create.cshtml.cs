using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera? Carrera { get; set; }
        public List<string> Modalities { get; set; } = Helpers.OpcionesModalidad.List;

        public void OnGet()
        {
            Modalities = OpcionesModalidad.List;

        }


        public IActionResult OnPost()
        {
            Modalities = OpcionesModalidad.List;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            ServiciosCarrera.Agregarcarrera(Carrera);
            return RedirectToPage("Index");
        }
    }
}