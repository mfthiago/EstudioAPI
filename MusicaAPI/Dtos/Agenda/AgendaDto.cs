using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agenda
{
    public class AgendaDto
    {

        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public int? SalaId { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }
    }
}
