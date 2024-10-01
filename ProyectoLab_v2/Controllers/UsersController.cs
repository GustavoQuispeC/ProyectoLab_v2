using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoLab.Shared.Request;
using ProyectoLab_v2.Services;

namespace ProyectoLab_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            var response = await _service.LoginAsync(request);
            return Ok(response);
        }


    }
}
