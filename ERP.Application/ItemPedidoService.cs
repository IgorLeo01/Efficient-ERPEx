using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ERP.Application
{
    public class ItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly ILogger<ItemPedidoService> _logger;

        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository, ILogger<ItemPedidoService> logger)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ItemPedido>> GetAllAsync()
        {
            try
            {
                return await _itemPedidoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all order items");
                throw;
            }
        }

        public async Task<ItemPedido> GetByIdAsync(int id)
        {
            try
            {
                return await _itemPedidoRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching order item with ID {id}");
                throw;
            }
        }

        public async Task AddAsync(ItemPedido itemPedido)
        {
            try
            {
                await _itemPedidoRepository.AddAsync(itemPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding order item");
                throw;
            }
        }

        public async Task UpdateAsync(ItemPedido itemPedido)
        {
            try
            {
                await _itemPedidoRepository.UpdateAsync(itemPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order item");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _itemPedidoRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting order item with ID {id}");
                throw;
            }
        }
    }
}
