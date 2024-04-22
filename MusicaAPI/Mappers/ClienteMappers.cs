using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Models;


namespace MusicaAPI.Mappers
{
    public static class ClienteMappers
    {
        public static ClienteDto ToClienteDto(this Cliente clienteModel)
        {
            return new ClienteDto
            {
                Id = clienteModel.Id,
                Nome = clienteModel.Nome,
                Email = clienteModel.Email,
                Telefone = clienteModel.Telefone,

            };
        }

        public static Cliente ToClienteFromCreateDTO(this CreateClienteRequestDto clienteDto)
        {
            return new Cliente
            {
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
                Telefone = clienteDto.Telefone,
            };
        }

    }
}
