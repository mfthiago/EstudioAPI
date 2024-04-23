namespace MusicaAPI.Models
{
    public class Estudio
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Endereco { get; set; }
        public List<Sala> Salas { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
