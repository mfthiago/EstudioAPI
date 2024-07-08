
using MusicaAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicaAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*builder.Entity<Agenda>(x => x.HasKey(p => new { p.AppUserId, p.AgendamentoId}));

            builder.Entity<Agenda>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Agendas)
                .HasForeignKey(p => p.AppUserId);
            
            builder.Entity<Agenda>()
                .HasMany(u => u.Agendamentos)
                .WithMany(u => u.Agendas)
                .HasForeignKey(p => p.AgendamentoId);*/
            



            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

        public DbSet<Agendamento> Agendamentos { get; set;}
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Equipamento> Equipamentos { get;set; }
        public DbSet<Estudio> Estudios { get; set; } 
        public DbSet<Sala> Salas { get; set; }


        


    }
}
