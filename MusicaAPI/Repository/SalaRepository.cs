using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;

using MusicaAPI.Dtos.Estudio;
using MusicaAPI.Dtos.Sala;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sala> CreateAsync(Sala salaModel)
        {
            await _context.Salas.AddAsync(salaModel);
            await _context.SaveChangesAsync();
            return salaModel;
        }

        public async Task<Sala?> DeleteAsync(int id)
        {
            var salaModel = await _context.Salas.FirstOrDefaultAsync(x => x.Id == id);
            if (salaModel == null)
            {
                return null;
            }
            _context.Salas.Remove(salaModel);
            await _context.SaveChangesAsync();

            return salaModel;
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            return await _context.Salas.Include(a => a.Agendamentos).ToListAsync();
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            return await _context.Salas.Include(a => a.Agendamentos).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> SalaExists(int id)
        {
            return _context.Salas.AnyAsync(a => a.Id == id);
        }

        public async Task<Sala?> UpdateAsync(int id, Sala salaModel)
        {
            var existingSala = await _context.Salas.FindAsync(id);
            if (existingSala == null)
            {
                return null;
            }

            existingSala.Nome = salaModel.Nome;
            existingSala.Preco = salaModel.Preco;


            await _context.SaveChangesAsync();
            return existingSala;

        }

    }
}

