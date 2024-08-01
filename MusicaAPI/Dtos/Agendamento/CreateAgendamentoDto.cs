using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Agendamento

{
    public class CreateAgendamentoDto
    {
        public double Preco{ get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataInicial { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataFinal { get; set; }
    }
}