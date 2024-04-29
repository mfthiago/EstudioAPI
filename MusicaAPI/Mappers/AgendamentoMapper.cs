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
                DataInicial = agendamentoModel.DataInicial,
                DataFinal = agendamentoModel.DataFinal
            };
        }
        public static Agendamento ToAgendamentoFromCreate(this CreateAgendamentoDto agendamentoDto, int clienteId
            ,int salaId)
        {
            return new Agendamento
            {
                ClienteId = clienteId,
                SalaId = salaId,
                DataInicial = agendamentoDto.DataInicial,
                DataFinal = agendamentoDto.DataFinal
            };
        }

        public static Agendamento ToAgendamentoFromUpdate(this UpdateAgendamentoRequestDto agendamentoDto)
        {
            return new Agendamento
            {
                DataInicial = agendamentoDto.DataInicial,
                DataFinal = agendamentoDto.DataFinal
            };
        }
    }
}
