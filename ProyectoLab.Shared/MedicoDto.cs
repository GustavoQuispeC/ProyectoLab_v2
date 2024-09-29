using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Shared
{
    public class MedicoDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
        public string Observaciones { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
