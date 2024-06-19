using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;
using System.Data.Entity.Validation;
using System.Linq;


namespace MusicaAPI.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {

        private readonly ApplicationDbContext _context;
        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AgendamentoExists(int id, Agendamento agendamentoModel)
        {
            var existingAgendamento = await _context.Agendamentos.FindAsync(id);
            if(existingAgendamento == null)
            {
                return false;
            }
            

            return await _context.Agendamentos.AnyAsync(a=> a.Id== id);
        }

        public async Task<bool> AgendamentoExistsData(Agendamento agendamentoModel, int salaId)
        {
            var salaAgendamento =  _context.Agendamentos.Select(s => s.SalaId); 
            var dataInicial = _context.Agendamentos.Select(x => x.DataInicial);
            var dataFinal = _context.Agendamentos.Select(x => x.DataFinal);

            if (salaAgendamento.Contains(salaId))
            {
                if (dataInicial.Contains(agendamentoModel.DataInicial) || (dataFinal.Contains(agendamentoModel.DataFinal)))
                {
                    return true;
                }
                else { return false; }
            }

            return await _context.Agendamentos.AnyAsync(a => a.DataInicial == agendamentoModel.DataInicial);
        }
      


        public async Task<Agendamento> CreateAsync(Agendamento agendamentoModel)
        {
            await _context.Agendamentos.AddAsync(agendamentoModel);
            await _context.SaveChangesAsync();
            return agendamentoModel; 
        }

        public async Task<Agendamento?> DeleteAsync(int id)
        {
            var agendamentoModel = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (agendamentoModel == null)
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
            existingAgendamento.DataInicial = agendamentoModel.DataInicial;
            existingAgendamento.DataFinal = agendamentoModel.DataFinal;

            await _context.SaveChangesAsync();
            return existingAgendamento;

        }

    }
}
