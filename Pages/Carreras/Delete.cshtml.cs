using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Carreras
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
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
            Carrera carreraAEliminar = null;
            foreach (var c in DatosCompartidos.Carreras)
            {
                if (c.Id == Carrera.Id)
                {
                    carreraAEliminar = c;
                    break;
                }
            }
            if (carreraAEliminar != null)
            {
                DatosCompartidos.Carreras.Remove(carreraAEliminar);
            }
            return RedirectToPage("Index");
        }
    }
}
