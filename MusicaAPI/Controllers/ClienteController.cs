using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Data;
using MusicaAPI.Mappers;
using MusicaAPI.Dtos;
using MusicaAPI.Dtos.Cliente;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Interfaces;
using MusicaAPI.Helpers;
using Microsoft.AspNetCore.Identity;
using MusicaAPI.Models;
using MusicaAPI.Service;


namespace MusicaAPI.Controllers
{
    [Route("MusicaAPI/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IClienteRepository _clienteRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;


        public ClienteController(UserManager<AppUser> userManager, ITokenService tokenService,ApplicationDbContext context, IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clientes = await _clienteRepo.GetAllAsync(query);
            var clienteDto = clientes.Select(s => s.ToClienteDto());

            return Ok(clienteDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cliente = await _clienteRepo.GetByIdAsync(id);

            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente.ToClienteDto());
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid) { 
                return BadRequest(ModelState);}

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,

                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                            );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }

                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }



            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClienteRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteModel = await _clienteRepo.UpdateAsync(id, updateDto);

            if(clienteModel == null)
            {
                return NotFound();
            }


            return Ok(clienteModel.ToClienteDto());

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteModel = await _clienteRepo.DeleteAsync(id);
            if(clienteModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
