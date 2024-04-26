
using MusicaAPI.Dtos.Estudio;
using MusicaAPI.Dtos.Sala;
using MusicaAPI.Models;

namespace MusicaAPI.Mappers
{
    public static class SalaMapper
    {
        public static SalaDto ToSalaDto(this Sala salaModel)
        {
            return new SalaDto
            {
                Id = salaModel.Id,
                EstudioId = salaModel.EstudioId,
                Nome = salaModel.Nome,
                Preco = salaModel.Preco,
                Agendamentos = salaModel.Agendamentos.Select(a => a.ToAgendamentoDto()).ToList(),
                Equipamentos = salaModel.Equipamentos.Select(s => s.ToEquipamentoDto()).ToList()
            };
        }
        public static Sala ToSalaFromCreateDto(this CreateSalaRequestDto salaDto, int estudioId)
        {
            return new Sala
            {
                Nome = salaDto.Nome,
                Preco = salaDto.Preco,
                EstudioId = estudioId
               
            };
        }
    }
}