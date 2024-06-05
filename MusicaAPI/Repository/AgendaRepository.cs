using MusicaAPI.Data;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicaAPI.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly ApplicationDbContext _context;
        public AgendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Agendamento>> GetUserAgenda(AppUser user)
        {
            return await _context.Agendas.Where(u => u.AppUserId == user.Id)
                .Select(agendamento => new Agendamento
                {
                    Id = agendamento.AgendamentoId,
                    ClienteId = agendamento.Agendamento.ClienteId,
                    SalaId = agendamento.Agendamento.SalaId,
                    DataInicial = agendamento.Agendamento.DataInicial,
                    DataFinal = agendamento.Agendamento.DataFinal
                    
                }).ToListAsync();
        }
    }
}
