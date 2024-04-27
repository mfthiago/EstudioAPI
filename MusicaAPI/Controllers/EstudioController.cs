using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Data;
using MusicaAPI.Mappers;
using MusicaAPI.Dtos;
using MusicaAPI.Dtos.Cliente;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Interfaces;
using MusicaAPI.Dtos.Estudio;

namespace MusicaAPI.Controllers
{
    [Route("MusicaAPI/Estudio")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEstudioRepository _estudioRepo;
        private readonly ISalaRepository _salaRepo;
        public EstudioController(ApplicationDbContext context, IEstudioRepository estudioRepo, ISalaRepository salaRepo)
        {
            _estudioRepo = estudioRepo;
            _salaRepo = salaRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudios = await _estudioRepo.GetAllAsync();
            var estudioDto = estudios.Select(e => e.ToEstudioDto());

            return Ok(estudioDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var estudio = await _estudioRepo.GetByIdAsync(id);

            if (estudio == null)
            {
                return NotFound();
            }
            return Ok(estudio.ToEstudioDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateEstudioRequestDto estudioDto)
        {
            var estudioModel = estudioDto.ToEstudioFromCreateDTO();
            await _estudioRepo.CreateAsync(estudioModel);
            return CreatedAtAction(nameof(GetById), new { id = estudioModel.Id }, estudioModel.ToEstudioDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEstudioRequestDto updateDto)
        {
            var estudioModel = await _estudioRepo.UpdateAsync(id, updateDto);

            if (estudioModel == null)
            {
                return NotFound();
            }


            return Ok(estudioModel.ToEstudioDto());

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var estudioModel = await _estudioRepo.DeleteAsync(id);
            if (estudioModel == null)
            {
                return NotFound();
            }

            return Ok(estudioModel);
        }
    }
}
