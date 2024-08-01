using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Interfaces;
using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Mappers;
using MusicaAPI.Data;
using MusicaAPI.Dtos.Equipamento;
using MusicaAPI.Dtos.Sala;

namespace MusicaAPI.Controllers
{

    [Route("api/Equipamento")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepo;
        private readonly ISalaRepository _salaRepo;
        public EquipamentoController(ApplicationDbContext applicationDbContext ,IEquipamentoRepository equipamentoRepo,ISalaRepository salaRepo)
        {
            _equipamentoRepo = equipamentoRepo;
            _salaRepo = salaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var equipamentos = await _equipamentoRepo.GetAllAsync();
            var equipamentoDto = equipamentos.Select(e => e.ToEquipamentoDto());

            return Ok(equipamentoDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var equipamento = await _equipamentoRepo.GetByIdAsync(id);

            if (equipamento == null)
            {
                return NotFound();
            }
            return Ok(equipamento.ToEquipamentoDto());
        }

        [HttpPost("{salaId:int}")]
        public async Task<IActionResult> Create([FromRoute] int salaId, CreateEquipamentoRequestDto equipamentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _salaRepo.SalaExists(salaId))
            {
                return BadRequest("Sala não existe");
            }
            var equipamentoModel = equipamentoDto.ToEquipamentoFromCreateDto(salaId);
            await _equipamentoRepo.CreateAsync(equipamentoModel);
            return CreatedAtAction(nameof(GetById), new { id = equipamentoModel.Id }, equipamentoModel.ToEquipamentoDto());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEquipamentoRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var equipamento = await _equipamentoRepo.UpdateAsync(id, updateDto);
            if (equipamento == null)
            {
                return NotFound("Equipamento não encontrada.");
            }
            return Ok(equipamento.ToEquipamentoDto());

        }



        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var equipamentoModel = await _equipamentoRepo.DeleteAsync(id);
            if (equipamentoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
