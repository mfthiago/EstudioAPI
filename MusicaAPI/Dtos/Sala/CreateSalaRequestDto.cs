using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Sala
{
    public class CreateSalaRequestDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }
    }
}
