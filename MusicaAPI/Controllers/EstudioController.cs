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
<<<<<<< HEAD
    [Route("api/Estudio")]
=======
    [Route("api/estudio")]
>>>>>>> a3d76c4b14726770120a040885f2ad4c800f4335
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEstudioRepository _estudioRepo;
        public EstudioController(ApplicationDbContext context, IEstudioRepository estudioRepo)
        {
            _estudioRepo = estudioRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var estudios = await _estudioRepo.GetAllAsync();
            var estudioDto = estudios.Select(e => e.ToEstudioDto());

            return Ok(estudioDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var estudioModel = estudioDto.ToEstudioFromCreateDTO();
            await _estudioRepo.CreateAsync(estudioModel);
            return CreatedAtAction(nameof(GetById), new { id = estudioModel.Id }, estudioModel.ToEstudioDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEstudioRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var estudioModel = await _estudioRepo.DeleteAsync(id);
            if (estudioModel == null)
            {
                return NotFound();
            }

            return Ok(estudioModel);
        }
    }
}
