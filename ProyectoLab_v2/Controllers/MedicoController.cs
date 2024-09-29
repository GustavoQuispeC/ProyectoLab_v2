using Microsoft.AspNetCore.Mvc;
using ProyectoLab.Entities;
using ProyectoLab.Repositories.Interfaces;
using ProyectoLab.Shared;

namespace ProyectoLab_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    { 
        private readonly IMedicoRepository _medicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicos()
        {
            var medicos = await _medicoRepository.ListAsync();
            return Ok(medicos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMedico(int id)
        {
            var medico = await _medicoRepository.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> PostMedico(MedicoDto request)
        {
            var medico = new Medico
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Especialidad = request.Especialidad,
                Observaciones = request.Observaciones,
                Telefono = request.Telefono,
                Correo = request.Correo
            };
            await _medicoRepository.AddAsync(medico);
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, MedicoDto request)
        {
            var medico = await _medicoRepository.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            medico.Nombres = request.Nombres;
            medico.Apellidos = request.Apellidos;
            medico.Especialidad = request.Especialidad;
            medico.Observaciones = request.Observaciones;
            medico.Telefono = request.Telefono;
            medico.Correo = request.Correo;

            await _medicoRepository.UpdateAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medicoRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
