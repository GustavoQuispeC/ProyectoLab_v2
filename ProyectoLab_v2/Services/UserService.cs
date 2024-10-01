﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProyectoLab.DataAccess;
using ProyectoLab.Repositories.Interfaces;
using ProyectoLab.Shared.Request;
using ProyectoLab.Shared.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security;
using System.Text;

namespace ProyectoLab_v2.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUserProyectoLab> _userManager;
        private readonly ILogger<UserService> _logger;
        private readonly IPacienteRepository _pacienteRepository; 

        public UserService(IConfiguration configuration, UserManager<IdentityUserProyectoLab> userManager, ILogger<UserService> logger, IPacienteRepository pacienteRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _logger = logger;
            _pacienteRepository = pacienteRepository;
        }

        public async Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request)
        {
            var response = new LoginDtoResponse();

            try
            {
                var identity = await _userManager.FindByNameAsync(request.Usuario);

                if (identity is null)
                    throw new SecurityException("Usuario no existe");

                // Validamos el usuario y clave.
                if (!await _userManager.CheckPasswordAsync(identity, request.Password))
                {
                    throw new SecurityException("Usuario o clave incorrecta");
                }

                var roles = await _userManager.GetRolesAsync(identity);
                var fechaExpiracion = DateTime.Now.AddHours(1);

                // Vamos a devolver los Claims
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, identity.NombreCompleto),
                //new Claim(ClaimTypes.Email, identity.Email!),
                new Claim(ClaimTypes.Expiration, fechaExpiracion.ToString("yyyy-MM-dd HH:mm:ss")),
            };

                claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

                response.Roles = roles.ToList();

                // Creamos el JWT
                var llaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
                var credenciales = new SigningCredentials(llaveSimetrica, SecurityAlgorithms.HmacSha256);

                var header = new JwtHeader(credenciales);

                var payload = new JwtPayload(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    DateTime.Now,
                    fechaExpiracion
                );

                var jwtToken = new JwtSecurityToken(header, payload);

                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                response.NombreCompleto = identity.NombreCompleto;
                response.Exito = true;

                _logger.LogInformation("Se creó el JWT de forma satisfactoria");

            }
            catch (SecurityException ex)
            {
                response.MensajeError = ex.Message;
                _logger.LogError(ex, "Error de seguridad {Message}", ex.Message);
            }
            catch (Exception ex)
            {
                response.MensajeError = "Error inesperado";
                _logger.LogError(ex, "Error al autenticar {Message}", ex.Message);
            }
            return response;
        }

        public Task<BaseResponse> RegisterAsync(RegistrarUsuarioDto request)
        {
            throw new NotImplementedException();
        }
    }
}