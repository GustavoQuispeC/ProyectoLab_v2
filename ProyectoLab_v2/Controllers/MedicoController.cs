using Microsoft.AspNetCore.Mvc;
using ProyectoLab.Entities;
using ProyectoLab.Repositories.Interfaces;

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
        public async Task<IActionResult> PostMedico(Medico medico)
        {
            await _medicoRepository.AddAsync(medico);
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Medico medico)
        {
            var registro = await _medicoRepository.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            registro.Nombres = medico.Nombres;
            registro.Apellidos = medico.Apellidos;
            registro.Especialidad = medico.Especialidad;
            registro.Observaciones = medico.Observaciones;
            registro.Telefono = medico.Telefono;
            registro.Correo = medico.Correo;

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
