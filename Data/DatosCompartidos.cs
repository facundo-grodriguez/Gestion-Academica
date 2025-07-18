using Microsoft.Extensions.Diagnostics.HealthChecks;
using SistemaAcademico.Models;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Data
{
    public class DatosCompartidos
    {
        public static List<Carrera> Carreras { get; set; } = new();
        public static List<Alumno> Alumnos { get; set; } = new();
        // private static int ultimoIdCarreras = 0; 
        private static int ultimoIdAlumnos = 0;
        public static int ObtenerNuevoIdCarreras()
        {
            // ultimoIdCarreras++;
            // return ultimoIdCarreras;
            int maxId = 0;
            foreach (var carrera in ServiciosCarrera.ObtenerCarrerasLista())
            {
                if (carrera.Id > maxId)
                {
                    maxId = carrera.Id;
                }
            }
            return maxId + 1;
        }
        public static int ObtenerNuevoIdAlumnos()
        {
            ultimoIdAlumnos++;
            return ultimoIdAlumnos;
        }
    }
}