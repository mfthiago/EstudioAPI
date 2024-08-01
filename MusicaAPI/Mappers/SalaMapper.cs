
using MusicaAPI.Dtos.Agendamento;
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
                Nome = salaModel.Nome,
                Preco = salaModel.Preco,

                Equipamentos = salaModel.Equipamentos.Select(s => s.ToEquipamentoDto()).ToList()
            };
        }
        public static Sala ToSalaFromCreateDto(this CreateSalaRequestDto salaDto)
        {
            return new Sala
            {
                Nome = salaDto.Nome,
                Preco = salaDto.Preco,

               
            };
        }
        public static Sala ToSalaFromUpdate(this UpdateSalaRequestDto salaDto)
        {
            return new Sala
            {
                Nome = salaDto.Nome,
                Preco = salaDto.Preco,
            };
        }
    }
}