using ProyectoLab.Shared.Request;
using ProyectoLab.Shared.Response;

namespace ProyectoLab_v2.Services
{
    public interface IUserService
    {
        Task<LoginDtoResponse>LoginAsync(LoginDtoRequest request);
        Task<BaseResponse>RegisterAsync(RegistrarUsuarioDto request);
    }
}
