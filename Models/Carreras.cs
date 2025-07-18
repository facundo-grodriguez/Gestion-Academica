﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SistemaAcademico.Models
{
    public class Carrera
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "debe agregar un nombre")]
        [StringLength(50, ErrorMessage = "no puede superar los 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "debe agregar un numero")]
        public int Anios { get; set; }

        [Required(ErrorMessage = "debe seleccionar un titulo")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "debe seleccionar una modalidad")]
        public string? Modalidad { get; set; }
    }
}