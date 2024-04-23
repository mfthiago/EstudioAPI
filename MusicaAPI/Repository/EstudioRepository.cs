using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;

using MusicaAPI.Dtos.Estudio;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Estudio> CreateAsync(Estudio estudioModel)
        {
            await _context.Estudios.AddAsync(estudioModel);
            await _context.SaveChangesAsync();
            return estudioModel;
        }

        public async Task<Estudio?> DeleteAsync(int id)
        {
            var estudioModel = await _context.Estudios.FirstOrDefaultAsync(x => x.Id == id);
            if (estudioModel == null)
            {
                return null;
            }
            _context.Estudios.Remove(estudioModel);
            await _context.SaveChangesAsync();

            return estudioModel;
        }

        public async Task<List<Estudio>> GetAllAsync()
        {
            return await _context.Estudios.Include(a => a.Agendamentos).ToListAsync();
        }

        public async Task<Estudio?> GetByIdAsync(int id)
        {
            return await _context.Estudios.Include(a => a.Agendamentos).FirstOrDefaultAsync(i => i.Id == id);
        }
       
        public async Task<Estudio?> UpdateAsync(int id, UpdateEstudioRequestDto estudioDto)
        {
            var existingEstudio = await _context.Estudios.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEstudio == null)
            {
                return null;
            }

            existingEstudio.Nome = estudioDto.Nome;
            existingEstudio.Endereco = estudioDto.Endereco;
            existingEstudio.Telefone = estudioDto.Telefone;

            await _context.SaveChangesAsync();
            return existingEstudio;

        }

    }
}

