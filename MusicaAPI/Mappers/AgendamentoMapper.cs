using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Migrations;
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
                AppUserName = agendamentoModel.AppUserName,
                EstudioId = agendamentoModel.EstudioId,
                Preco = agendamentoModel.Preco,
                DataInicial = agendamentoModel.DataInicial,
                DataFinal = agendamentoModel.DataFinal
            };
        }
<<<<<<< HEAD
        public static Agendamento ToAgendamentoFromCreate(this CreateAgendamentoDto agendamentoDto, string appUserName
            , int estudioId)
        {
            return new Agendamento
            {
                AppUserName = appUserName,
                EstudioId = estudioId,
                Preco = agendamentoDto.Preco,
=======
        public static Agendamento ToAgendamentoFromCreate(this CreateAgendamentoDto agendamentoDto
            , int salaId)
        {
            return new Agendamento
            {
                SalaId = salaId,
>>>>>>> a3d76c4b14726770120a040885f2ad4c800f4335
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
