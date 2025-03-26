using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(ApplicationDbContext context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all clients ");
                throw;
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Clientes.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting client with id: {id}");
                throw;
            }
        }

        public async Task AddAsync(Cliente cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding Client to database: ");
                throw;
            }
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating client: ");
                throw;
            }
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    _logger.LogWarning($"Client with ID {id} not found for exclusion.");
                    throw new KeyNotFoundException("Client not found");
                }
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing Client with ID: {id}");
                throw;
            }
        }

    }
}
