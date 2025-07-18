using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Alumno? Alumno { get; set; }

        private readonly ServicioAlumno servicio;
        public DeleteModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatosJson<Alumno>("Alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            servicio = new ServicioAlumno(repo);
        }
        public IActionResult OnGet(int id)
        {
            var alumno = servicio.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("Index");
            }
            Alumno = alumno;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
