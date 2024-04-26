using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Agendamento?> DeleteAsync(int id)
        {
            var agendamentoModel = await _context.Agendamentos.FirstOrDefaultAsync(a=>a.Id== id);   

            if(agendamentoModel == null)
            {
                return null;
            }
            _context.Agendamentos.Remove(agendamentoModel);
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

        public async Task<Agendamento?> UpdateAsync(int id, Agendamento agendamentoModel)
        {
            var existingAgendamento = await _context.Agendamentos.FindAsync(id);
            
            if(existingAgendamento == null)
            {
                return null;
            }
            existingAgendamento.Data = agendamentoModel.Data;

            await _context.SaveChangesAsync();
            return existingAgendamento;

        }
    }
}
