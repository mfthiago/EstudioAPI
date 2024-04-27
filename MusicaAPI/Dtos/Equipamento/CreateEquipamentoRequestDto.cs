using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Equipamento
{
    public class CreateEquipamentoRequestDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Instrumento { get; set; } = string.Empty;

    }
}
