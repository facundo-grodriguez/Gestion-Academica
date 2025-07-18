using System.IO;
using System.Text.Json;
using SistemaAcademico.Models;
using System.Collections.Generic;
namespace SistemaAcademico.Servicios
{
    public class ServiciosCarrera
    {
        private static string path = "Data/Carreras.json";
        public static string LeerTextoDeJson()
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return "[]";
        }
        public static List<Carrera> ObtenerCarrerasLista()
        {
            string json = LeerTextoDeJson();
            var ListCarreras = JsonSerializer.Deserialize<List<Carrera>>(json);
            return ListCarreras ?? new List<Carrera>();
        }
    }
}