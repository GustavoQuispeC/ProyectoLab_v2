using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoLab.DataAccess;
using ProyectoLab.DataAccess.Data;
using ProyectoLab.Repositories.Implementaciones;
using ProyectoLab.Repositories.Interfaces;
using ProyectoLab_v2.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IMedicoRepository, MedicoRepository>();
builder.Services.AddTransient<IPacienteRepository, PacienteRepository>();


builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddDbContext<ProyectoLabDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProyectoLabDb"));
});

// Configuramos ASP.NET Identity Core
builder.Services.AddIdentity<IdentityUserProyectoLab, IdentityRole>(policies =>
{
    policies.Password.RequireDigit = false;
    policies.Password.RequireLowercase = true;
    policies.Password.RequireUppercase = true;
    policies.Password.RequireNonAlphanumeric = false;
    policies.Password.RequiredLength = 8;

    policies.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ProyectoLabDbContext>()
    .AddDefaultTokenProviders();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar política CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configurar autenticación con JWT Bearer
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ??
        throw new InvalidOperationException("No se configuró el SecretKey"));

    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar la política CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Habilitar autenticación
app.UseAuthentication();

// Habilitar autorización
app.UseAuthorization();

app.MapControllers();

app.Run();
