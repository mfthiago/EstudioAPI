using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Interfaces;
using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Mappers;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Models;
using MusicaAPI.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MusicaAPI.Controllers
{

<<<<<<< HEAD
    [Route("api/Agendamento")]
=======
    [Route("api/agendamento")]
>>>>>>> a3d76c4b14726770120a040885f2ad4c800f4335
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAgendamentoRepository _agendamentoRepo;
        private readonly IClienteRepository _clienteRepo;
        private readonly IEstudioRepository _estudioRepo;

        public AgendamentoController(UserManager<AppUser> userManager,IAgendamentoRepository agendamentoRepo, IClienteRepository clienteRepo, IEstudioRepository estudioRepo)
        {
            _userManager = userManager;
            _agendamentoRepo = agendamentoRepo;
            _clienteRepo = clienteRepo;
            _estudioRepo = estudioRepo;
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserAgenda()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userAgenda = await _agendamentoRepo.GetUserAgenda(appUser);
            return Ok(userAgenda);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agendamentos = await _agendamentoRepo.GetAllAsync();
            var agendamentoDto = agendamentos.Select(s => s.ToAgendamentoDto());

            return Ok(agendamentoDto);

        }
        

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agendamento = await _agendamentoRepo.GetByIdAsync(id);

            if(agendamento == null)
            {
                return NotFound();
            }
            return Ok(agendamento.ToAgendamentoDto());
        }

        [HttpPost("{estudioId:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int estudioId, CreateAgendamentoDto agendamentoDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
<<<<<<< HEAD

            var agendamentoModel = agendamentoDto.ToAgendamentoFromCreate(username,estudioId);
=======
            if (
                !await _salaRepo.SalaExists(salaId))
            {
                return BadRequest("Informações inválidas");
            }
            var agendamentoModel = agendamentoDto.ToAgendamentoFromCreate(salaId);
            agendamentoModel.AppUserName = appUser.UserName;
>>>>>>> a3d76c4b14726770120a040885f2ad4c800f4335
            var minDate = DateTime.Now;
            if(agendamentoModel.DataInicial <= minDate || agendamentoModel.DataFinal<= minDate || agendamentoModel.DataFinal<= agendamentoModel.DataInicial)
            {
                return BadRequest("Data inválida");
            }
            if (await _agendamentoRepo.AgendamentoExistsData(agendamentoModel,estudioId))
            {
                return BadRequest("Já existe um agendamento nesse horário");
            }
            await _agendamentoRepo.CreateAsync(agendamentoModel);
            return CreatedAtAction(nameof(GetById), new { id = agendamentoModel.Id }, agendamentoModel.ToAgendamentoDto());
        }

        [HttpPut]
        [Route("{id:int},{estudioId:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAgendamentoRequestDto updateDto,int estudioId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agendamento = await _agendamentoRepo.UpdateAsync(id, updateDto.ToAgendamentoFromUpdate());
            if(agendamento == null)
            {
                return NotFound("Agendamento não encontrado.");
            }
            if (!await _estudioRepo.EstudioExists(estudioId))
            {
                return BadRequest("Informações inválidas");
            }
            var minDate = DateTime.Now;
            if (agendamento.DataInicial < minDate)
            {
                return BadRequest("Data inválida");
            }
            if (await _agendamentoRepo.AgendamentoExistsData(agendamento, estudioId))
            {
                return BadRequest("Já existe um agenndamento nesse horário");
            }
            return Ok(agendamento.ToAgendamentoDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agendamentoModel = await _agendamentoRepo.DeleteAsync(id);
            if(agendamentoModel == null)
            {
                return NotFound("Agendamento não existe.");
            }
            return Ok(agendamentoModel);

        }



    }
}
