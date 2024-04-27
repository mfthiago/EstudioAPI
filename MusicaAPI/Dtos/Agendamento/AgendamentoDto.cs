using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agendamento
{
    public class AgendamentoDto
    {

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? SalaId { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
