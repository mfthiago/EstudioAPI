using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Dtos.Equipamento;
using MusicaAPI.Dtos.Sala;
using MusicaAPI.Models;

namespace MusicaAPI.Mappers
{
    public static class EquipamentoMapper
    {
        public static EquipamentoDto ToEquipamentoDto(this Equipamento equipamentoModel)
        {
            return new EquipamentoDto
            {
                Id = equipamentoModel.Id,
                SalaId = equipamentoModel.SalaId,
                Instrumento = equipamentoModel.Instrumento,
                Nome = equipamentoModel.Nome,
                

            };
        }
        public static Equipamento ToEquipamentoFromCreateDto(this CreateEquipamentoRequestDto equipamentoDto, int salaId)
        {
            return new Equipamento
            {
                Nome = equipamentoDto.Nome,
                Instrumento = equipamentoDto.Instrumento,
                SalaId = salaId,

            };
        }
        public static Equipamento ToEquipamentoFromUpdate(this UpdateEquipamentoRequestDto equipamentoDto)
        {
            return new Equipamento
            {
                Nome = equipamentoDto.Nome,
                Instrumento = equipamentoDto.Instrumento,
            };
        }
    }
}