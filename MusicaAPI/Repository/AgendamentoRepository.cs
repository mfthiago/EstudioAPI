using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {

        private readonly ApplicationDbContext _context;
        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Agendamento>> GetAllAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }
    }
}
