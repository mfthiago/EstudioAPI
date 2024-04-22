namespace MusicaAPI.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;

        public Equipamento(){ }

    }
}
