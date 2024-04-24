using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;
using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Dtos.Equipamento;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repository
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Equipamento> CreateAsync(Equipamento equipamentoModel)
        {
            await _context.Equipamentos.AddAsync(equipamentoModel);
            await _context.SaveChangesAsync();
            return equipamentoModel;
        }

        public async Task<Equipamento?> DeleteAsync(int id)
        {
            var equipamentoModel = await _context.Equipamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (equipamentoModel == null)
            {
                return null;
            }
            _context.Equipamentos.Remove(equipamentoModel);
            await _context.SaveChangesAsync();

            return equipamentoModel;
        }

        public Task<bool> EquipamentoExists(int id)
        {
            return _context.Equipamentos.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Equipamento>> GetAllAsync()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        public async Task<Equipamento?> GetByIdAsync(int id)
        {
            return await _context.Equipamentos.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Equipamento?> UpdateAsync(int id, UpdateEquipamentoRequestDto equipamentoDto)
        {
            var existingEquipamento = await _context.Equipamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEquipamento == null)
            {
                return null;
            }

            existingEquipamento.Nome = equipamentoDto.Nome;
            existingEquipamento.Instrumento = equipamentoDto.Instrumento;
            

            await _context.SaveChangesAsync();
            return existingEquipamento;

        }
    }
}
