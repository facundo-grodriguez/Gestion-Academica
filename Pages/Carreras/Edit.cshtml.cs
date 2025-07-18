using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Carreras
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public required Carrera Carrera { get; set; }
        public void OnGet(int id)
        {
            foreach (var c in DatosCompartidos.Carreras)
            {
                if (c.Id == id)
                {
                    Carrera = c;
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

            foreach (var c in DatosCompartidos.Carreras)
            {
                if (c.Id == Carrera.Id)
                {
                    c.Nombre = Carrera.Nombre;
                    c.Modalidad = Carrera.Modalidad;
                    c.Anios = Carrera.Anios;
                    string? title = Carrera.Titulo;
                    c.Titulo = title;
                    break;
                }
            }

            return RedirectToPage("Index");
        }
    }
}
