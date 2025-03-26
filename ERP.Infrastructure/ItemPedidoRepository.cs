using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ItemPedidoRepository> _logger;

        public ItemPedidoRepository(ApplicationDbContext context, ILogger<ItemPedidoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ItemPedido>> GetAllAsync()
        {
            try
            {
                return await _context.ItensPedido.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all items from order");
                throw;
            }
        }

        public async Task<ItemPedido> GetByIdAsync(int id)
        {
            try
            {
                return await _context.ItensPedido.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting order item with ID {id}");
                throw;
            }
        }

        public async Task AddAsync(ItemPedido itemPedido)
        {
            try
            {
                await _context.ItensPedido.AddAsync(itemPedido);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new item to order");
                throw;
            }
        }

        public async Task UpdateAsync(ItemPedido itemPedido)
        {
            try
            {
                _context.ItensPedido.Update(itemPedido);
                await _context.SaveChangesAsync();
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
                var itemPedido = await _context.ItensPedido.FindAsync(id);
                if (itemPedido == null)
                {
                    _logger.LogWarning($"Order item with ID {id} not found for deletion.");
                    throw new KeyNotFoundException("Order item not found");
                }
                _context.ItensPedido.Remove(itemPedido);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing item from order with ID {id}");
                throw;
            }
        }
    }
}
