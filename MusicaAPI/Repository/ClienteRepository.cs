using Microsoft.EntityFrameworkCore;
using MusicaAPI.Data;
using MusicaAPI.Dtos.Cliente;
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

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
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
