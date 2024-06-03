using System.ComponentModel.DataAnnotations.Schema;

namespace MusicaAPI.Models
{
    [Table("Equipamentos")]
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;
        public int SalaId{ get; set; }
        public Sala? Sala{ get; set; }

        public Equipamento()
        {
            
        }
    }
}
