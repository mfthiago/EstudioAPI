using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Interfaces;
using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Mappers;
using MusicaAPI.Data;
using MusicaAPI.Dtos.Equipamento;

namespace MusicaAPI.Controllers
{

    [Route("MusicaAPI/Equipamento")]
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
            var equipamentos = await _equipamentoRepo.GetAllAsync();
            var equipamentoDto = equipamentos.Select(e => e.ToEquipamentoDto());

            return Ok(equipamentoDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
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
            if (!await _salaRepo.SalaExists(salaId))
            {
                return BadRequest("Informações inválidas");
            }
            var equipamentoModel = equipamentoDto.ToEquipamentoFromCreate(salaId);
            await _equipamentoRepo.CreateAsync(equipamentoModel);
            return CreatedAtAction(nameof(GetById), new { id = equipamentoModel.Id }, equipamentoModel.ToEquipamentoDto());
        }
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var equipamentoModel = await _equipamentoRepo.DeleteAsync(id);
            if (equipamentoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
