namespace MusicaAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; } 
        public int? SalaId { get; set; }
        public Sala? Sala { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public Agendamento() { }

    }
}
