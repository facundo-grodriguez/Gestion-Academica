using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Carreras
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public required Carrera Carrera { get; set; }

        private readonly ServicioCarrera Servicio;
        public DeleteModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatosJson<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            Servicio = new ServicioCarrera(repo);
        }
        public IActionResult OnGet(int id)
        {
            var carrera = Servicio.BuscarPorId(id); 
            if (carrera == null)
            {
                return RedirectToPage("Index");
            }
            Carrera = carrera;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            Servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
