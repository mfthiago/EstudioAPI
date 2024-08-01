using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Estudio
{
    public class CreateEstudioRequestDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage =
            "Número inválido.")]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Endereco { get; set; } = string.Empty;
        [Required]
        public double Preco { get; set; }
        [Required]

        public int CheckIn { get; set; }
        [Required]

        public int CheckOut { get; set; }
    }
}
