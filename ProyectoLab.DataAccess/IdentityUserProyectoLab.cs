using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.DataAccess
// IdentityUserProyectoLab hereda de IdentityUser
{
    public class IdentityUserProyectoLab : IdentityUser
    {
        [StringLength(200)]
        public string NombreCompleto { get; set; } = default!;

        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(250)]
        public string? Direccion { get; set; }
    }
}
