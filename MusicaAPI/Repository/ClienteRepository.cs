using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;
using MusicaAPI.Dtos.Cliente;
using MusicaAPI.Helpers;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

namespace MusicaAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente clienteModel)
        {
            await _context.Clientes.AddAsync(clienteModel);
            await _context.SaveChangesAsync();
            return clienteModel;
        }

        public async Task<Cliente?> DeleteAsync(int id)
        {
            var clienteModel = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if(clienteModel == null) 
            {
                return null;
            }
            _context.Clientes.Remove(clienteModel);
            await _context.SaveChangesAsync();
            
            return clienteModel;
        }

        public async Task<List<Cliente>> GetAllAsync(QueryObject query)
        {
            var clientes =  _context.Clientes.Include(a => a.Agendamentos).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Nome))
            {
                clientes = clientes.Where(n => n.Nome.Contains(query.Nome));
            }
            if(!string.IsNullOrWhiteSpace(query.Email))
            {
                clientes = clientes.Where(e => e.Equals(query.Email));
            }
            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Nome", StringComparison.OrdinalIgnoreCase))
                {
                    clientes = query.IsDescending ? clientes.OrderByDescending(n => n.Nome) : clientes.OrderBy(n => n.Nome);
                }
            }
            return await clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.Include(a => a.Agendamentos).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> ClienteExists(int id)
        {
            return _context.Clientes.AnyAsync(c => c.Id == id);
        }

        public async Task<Cliente?> UpdateAsync(int id, UpdateClienteRequestDto clienteDto)
        {
            var existingCliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCliente == null)
            {
                return null;
            }

            existingCliente.Nome = clienteDto.Nome;
            existingCliente.Email = clienteDto.Email;
            existingCliente.Telefone = clienteDto.Telefone;

            await _context.SaveChangesAsync();
            return existingCliente;

        }
    }
}
