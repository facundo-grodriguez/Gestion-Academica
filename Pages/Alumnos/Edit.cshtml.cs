using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public required Alumno Alumno { get; set; }

        private readonly ServicioAlumno servicio;
        public EditModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatosJson<Alumno>("Alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            servicio = new ServicioAlumno(repo);
        }
        public void OnGet(int id)
        {
            Alumno? alumno = servicio.BuscarPorId(id);
            if (alumno != null)
            {
                Alumno = alumno;
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            servicio.Editar(Alumno);

            return RedirectToPage("Index");
        }
    }
}
