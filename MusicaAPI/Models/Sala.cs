﻿namespace MusicaAPI.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public int? EstudioId { get; set; }
        public Estudio? Estudio { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
 

        public Sala()
        {
            
        }
    }
}
