using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Dtos.Cliente
{
    public class CreateClienteRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage =
            "Nome tem que possuir mais que três letras")]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Endereço de email inválido")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage =
            "Número inválido.")]
        public string Telefone { get; set; } = string.Empty;

    }
}
