using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Models;

namespace MusicaAPI.Mappers
{
    public static class AgendamentoMapper
    {
        public static AgendamentoDto ToAgendamentoDto(this Agendamento agendamentoModel)
        {
            return new AgendamentoDto
            {
                Id = agendamentoModel.Id,
                ClienteId = agendamentoModel.ClienteId,
                SalaId = agendamentoModel.SalaId,
                Data = agendamentoModel.Data,
            };
        }
        public static Agendamento ToAgendamentoFromCreate(this CreateAgendamentoDto agendamentoDto, int clienteId
            ,int salaId)
        {
            return new Agendamento
            {
                ClienteId = clienteId,
                SalaId = salaId,
                Data = agendamentoDto.Data
            };
        }
    }
}
