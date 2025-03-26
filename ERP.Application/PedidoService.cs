using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ERP.Application
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<PedidoService> _logger;

        public PedidoService(IPedidoRepository pedidoRepository, ILogger<PedidoService> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            try
            {
                return await _pedidoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all orders");
                throw;
            }
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            try
            {
                return await _pedidoRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching order with ID {id}");
                throw;
            }
        }

        public async Task AddAsync(Pedido pedido)
        {
            try
            {
                await _pedidoRepository.AddAsync(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding order");
                throw;
            }
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            try
            {
                await _pedidoRepository.UpdateAsync(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _pedidoRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting order with ID {id}");
                throw;
            }
        }
    }
}
