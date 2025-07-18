using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Helpers;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera? Carrera { get; set; }
        public List<string> Modalities { get; set; } = Helpers.OpcionesModalidad.List;

        private readonly ServicioCarrera Servicio;
        public CreateModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatosJson<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            Servicio = new ServicioCarrera(repo);
        }
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
            Servicio.Agregar(carrera: Carrera);
            return RedirectToPage("Index");
        }
    }
}