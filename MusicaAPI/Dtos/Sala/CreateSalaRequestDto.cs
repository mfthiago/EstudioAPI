﻿namespace MusicaAPI.Dtos.Sala
{
    public class CreateSalaRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}
