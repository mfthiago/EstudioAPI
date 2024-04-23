namespace MusicaAPI.Dtos.Sala
{
    public class SalaDto
    {
        public int Id { get; set; }
        public int? EstudioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
    }
}
