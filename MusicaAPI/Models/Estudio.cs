using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Estudios")]
    public class Estudio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }
        public List<Sala> Salas { get; set; } = new List<Sala>();

        public Estudio() { }
    }
}
