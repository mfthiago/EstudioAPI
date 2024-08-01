using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Salas")]
    public class Sala
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

        public Sala() { }
    }
}
