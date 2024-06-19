using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {
        public int Id { get; set; }
        public int? SalaId { get; set; }
        public Sala? Sala { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public List<Agenda> Agendas { get; set; } = new List<Agenda>();

        public Agendamento() { }

    }
}
