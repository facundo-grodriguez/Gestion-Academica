using System.Text.Json;
namespace SistemaAcademico.AccesoDatos
{
    public class AccesoDatosJson<T> : IAccesoDatos<T> where T : class
    {
        private string ruta;
        public AccesoDatosJson(string nombreArchivo)
        {
            ruta = $"Data/{nombreArchivo}.json";
        }

        //Metodos sin reflexion
        public string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]";
        }
        public List<T> Leer()
        {
            string json = LeerTextoDelArchivo();
            var lista = JsonSerializer.Deserialize<List<T>>(json);
            return lista ?? new List<T>();
        }
        public void Guardar(List<T> lista)
        {
            string json = JsonSerializer.Serialize(lista);
            File.WriteAllText(ruta, json);
        }
    }
}