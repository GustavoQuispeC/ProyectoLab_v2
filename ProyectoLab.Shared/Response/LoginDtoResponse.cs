using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Shared.Response
{
    public class LoginDtoResponse : BaseResponse
    {
        public string Token { get; set; } = default!;

        public string NombreCompleto { get; set; } = default!;

        public List<string> Roles { get; set; } = default!;
    }
}
