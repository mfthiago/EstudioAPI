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

        public Task<bool> AgendamentoExists(int id)
        {
            return _context.Agendamentos.AnyAsync(a=> a.Id== id);
        }

        public async Task<Agendamento> CreateAsync(Agendamento agendamentoModel)
        {
            await _context.Agendamentos.AddAsync(agendamentoModel);
            await _context.SaveChangesAsync();
            return agendamentoModel; 
        }

        public async Task<List<Agendamento>> GetAllAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _context.Agendamentos.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
