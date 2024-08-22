using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Interfaces;
using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Mappers;
using MusicaAPI.Dtos.Sala;

namespace MusicaAPI.Controllers
{


    [Route("api/Sala")]

    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepo;
        private readonly IEstudioRepository _estudioRepo;
        private readonly ISalaRepository _salaRepo;
        public SalaController(IAgendamentoRepository agendamentoRepo, IEstudioRepository estudioRepo, ISalaRepository salaRepo)
        {
            _agendamentoRepo = agendamentoRepo;
            _estudioRepo = estudioRepo;
            _salaRepo = salaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salas = await _salaRepo.GetAllAsync();
            var salaDto = salas.Select(s => s.ToSalaDto());

            return Ok(salaDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sala = await _salaRepo.GetByIdAsync(id);

            if (sala == null)
            {
                return NotFound();
            }
            return Ok(sala.ToSalaDto());
        }

        [HttpPost("{estudioId:int}")]
        public async Task<IActionResult> Create([FromRoute] int estudioId, CreateSalaRequestDto salaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _estudioRepo.EstudioExists(estudioId))
            {
                return BadRequest("Estúdio não existe.");
            }
            var salaModel = salaDto.ToSalaFromCreateDto();
            await _salaRepo.CreateAsync(salaModel);
            return CreatedAtAction(nameof(GetById), new { id = salaModel.Id }, salaModel.ToSalaDto());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSalaRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sala = await _salaRepo.UpdateAsync(id, updateDto.ToSalaFromUpdate());
            if (sala == null)
            {
                return NotFound("Sala não encontrada.");
            }
            return Ok(sala.ToSalaDto());

        }
       
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salaModel = await _salaRepo.DeleteAsync(id);
            if (salaModel == null)
            {
                return NotFound("Sala não existe.");
            }
            return Ok(salaModel);

        }

    }
}
