using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agendamento
{
    public class AgendamentoDto
    {

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? SalaId { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }
    }
}
