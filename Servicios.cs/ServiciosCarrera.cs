using System.IO;
using System.Text.Json;
using SistemaAcademico.Models;
using SistemaAcademico.Data;
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

        public static void Agregarcarrera(Carrera nuevaCarrera)
        {
            var carreras = ObtenerCarrerasLista();
            nuevaCarrera.Id = DatosCompartidos.ObtenerNuevoIdCarreras();
            carreras.Add(nuevaCarrera);
            GuardarCarreras(carreras);
        }

        public static void GuardarCarreras(List<Carrera> carreras)
        {
            string json = JsonSerializer.Serialize(carreras);
            File.WriteAllText(path, json);
        }

        public static Carrera? ObtenerCarreraPorId(int id)
        {
            var carreras = ObtenerCarrerasLista();
            return carreras.Find(c => c.Id == id);
        }

        public static void EliminarCarrera(int id)
        {
            var carreras = ObtenerCarrerasLista();
            var carreraAEliminar = carreras.Find(c => c.Id == id);
            if (carreraAEliminar != null)
            {
                carreras.Remove(carreraAEliminar);
                GuardarCarreras(carreras);
            }
        }

        public static void editarCarrera(Carrera carreraEditada)
        {
            var carreras = ObtenerCarrerasLista();
            foreach (var carrera in carreras)
            {
                if (carrera.Id == carreraEditada.Id)
                {
                    carrera.Nombre = carreraEditada.Nombre;
                    carrera.Modalidad = carreraEditada.Modalidad;
                    carrera.Anios = carreraEditada.Anios;
                    carrera.Titulo = carreraEditada.Titulo;
                    break;
                }
            }
            GuardarCarreras(carreras);
        }
    }
}