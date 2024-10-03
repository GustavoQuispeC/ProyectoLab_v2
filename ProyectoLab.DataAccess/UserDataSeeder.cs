using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProyectoLab.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.DataAccess
{
    public class UserDataSeeder
    {
        public static async Task Seed(IServiceProvider service)
        {
            // UserManager (Repositorio de Usuarios)
            var userManager = service.GetRequiredService<UserManager<IdentityUserProyectoLab>>();
            // RoleManager (Repositorio de Roles)
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            // Crear los roles
            var adminRole = new IdentityRole(Constantes.RolAdministrador);
            var clienteRole = new IdentityRole(Constantes.RolCliente);
            var medicoRole = new IdentityRole(Constantes.RolMedico);
            var tecnicoRole = new IdentityRole(Constantes.RolTecnico);
            var tecnologoRole = new IdentityRole(Constantes.RolTecnologo);
            var pacienteRole = new IdentityRole(Constantes.RolPaciente);



            if (!await roleManager.RoleExistsAsync(Constantes.RolAdministrador))
            {
                await roleManager.CreateAsync(adminRole);
            }

            if (!await roleManager.RoleExistsAsync(Constantes.RolCliente))
            {
                await roleManager.CreateAsync(clienteRole);
            }

            if (!await roleManager.RoleExistsAsync(Constantes.RolMedico))
            {
                await roleManager.CreateAsync(medicoRole);
            }

            if (!await roleManager.RoleExistsAsync(Constantes.RolTecnico))
            {
                await roleManager.CreateAsync(tecnicoRole);
            }

            if (!await roleManager.RoleExistsAsync(Constantes.RolTecnologo))
            {
                await roleManager.CreateAsync(tecnologoRole);
            }

            if (!await roleManager.RoleExistsAsync(Constantes.RolPaciente))
            {
                await roleManager.CreateAsync(pacienteRole);
            }

            // Creamos el usuario Administrador
            var adminUser = new IdentityUserProyectoLab
            {
                NombreCompleto = "Administrador del Sistema",
                FechaNacimiento = DateTime.Parse("1990-01-01"),
                Direccion = "Av. Siempre viva 123",
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "pa$$W0rD@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
            }
        }
    }
}
