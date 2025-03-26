using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ERP.Application
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                return await _clienteRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all clients");
                throw;
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            try
            {
                return await _clienteRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching client with ID {id}");
                throw;
            }
        }

        public async Task AddAsync(Cliente cliente)
        {
            try
            {
                await _clienteRepository.AddAsync(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding client");
                throw;
            }
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            try
            {
                await _clienteRepository.UpdateAsync(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating client");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _clienteRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting client with ID {id}");
                throw;
            }
        }
    }
}
