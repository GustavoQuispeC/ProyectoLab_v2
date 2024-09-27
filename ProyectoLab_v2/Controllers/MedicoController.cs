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

        [HttpPost]
        public async Task<IActionResult> PostMedico(Medico medico)
        {
            await _medicoRepository.AddAsync(medico);
            return Ok();
        }
    }
}
