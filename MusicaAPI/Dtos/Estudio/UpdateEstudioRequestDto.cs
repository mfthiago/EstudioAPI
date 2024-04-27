using MusicaAPI.Dtos.Sala;
using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Estudio
{
    public class UpdateEstudioRequestDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage =
            "Número inválido.")]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Endereco { get; set; } = string.Empty;
        public List<SalaDto> Salas { get; set; } = new List<SalaDto>();
    }
}
