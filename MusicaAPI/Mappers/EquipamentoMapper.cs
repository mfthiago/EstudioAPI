using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Dtos.Equipamento;
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
                Instrumento = equipamentoModel.Instrumento,
                Nome = equipamentoModel.Nome,
                SalaId = equipamentoModel.SalaId,

            };
        }
        public static Equipamento ToEquipamentoFromCreate(this CreateEquipamentoRequestDto equipamentoDto, int salaId)
        {
            return new Equipamento
            {
                SalaId = salaId
            };
        }
    }
}