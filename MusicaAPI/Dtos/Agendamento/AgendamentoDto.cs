namespace MusicaAPI.Dtos.Agendamento
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? EstudioId { get; set; }
        public int? SalaId { get; set; }
        public DateTime Data { get; set; }
    }
}
