using Microsoft.EntityFrameworkCore;
using MusicaAPI.Models;

namespace MusicaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Agendamento> Agendamentos { get; set;}
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Equipamento> Equipamentos { get;set; }
        public DbSet<Estudio> Estudios { get; set; } 
        public DbSet<Sala> Salas { get; set; }


    }
}
