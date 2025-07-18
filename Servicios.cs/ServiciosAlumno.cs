using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace SistemaAcademico.Servicios
{
    public class ServicioAlumno
    {
        private readonly IRepositorio<Alumno> _repo;
        public ServicioAlumno(IRepositorio<Alumno> repo)
        {
            _repo = repo;
        }
        public List<Alumno> ObtenerDatos()
        {
            return _repo.ObtenerDatos();
        }
        public Alumno? BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }
        public void Agregar(Alumno Alumno)
        {
            _repo.Agregar(Alumno);
        }
        public void Editar(Alumno Alumno)
        {
            _repo.Editar(Alumno);
        }
        public void EliminarPorId(int id)
        {
            _repo.EliminarPorId(id);
        }


    }
}