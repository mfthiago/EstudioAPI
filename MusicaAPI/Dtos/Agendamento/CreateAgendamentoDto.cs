using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agendamento
{
    public class CreateAgendamentoDto
    {

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataInicial { get; set; }
        [Required]

        [DataType(DataType.DateTime)]
        public DateTime DataFinal { get; set; }
    }
}
