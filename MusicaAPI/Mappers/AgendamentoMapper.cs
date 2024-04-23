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
                EstudioId = agendamentoModel.EstudioId,
                Data = agendamentoModel.Data,
            };
        }
    }
}
