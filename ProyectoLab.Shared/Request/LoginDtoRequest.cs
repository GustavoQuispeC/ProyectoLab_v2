using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Shared.Request
{
    public class LoginDtoRequest()
    {
        public string Usuario { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
