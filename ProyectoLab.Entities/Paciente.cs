using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Entities
{
    public class Paciente : EntityBase
    {
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public DateOnly FechaNacimiento { get; set; }
        public string Dni { get; set; } = default!;
        public string genero { get; set; } = default!;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Observaciones { get; set; }
    }
}
