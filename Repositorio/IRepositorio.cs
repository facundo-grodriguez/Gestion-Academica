namespace SistemaAcademico.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObtenerDatos();
        T? BuscarPorId(int id);
        void Agregar(T e);
        void Editar(T e);
        void EliminarPorId(int id);
    }
}