namespace MusicaAPI.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;
        public int SalaId{ get; set; }
        public Sala Sala{ get; set; } = new Sala();

        public Equipamento()
        {
            
        }

    }
}
