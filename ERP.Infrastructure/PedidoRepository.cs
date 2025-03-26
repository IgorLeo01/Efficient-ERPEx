using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PedidoRepository> _logger;

        public PedidoRepository(ApplicationDbContext context, ILogger<PedidoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            try
            {
                return await _context.Pedidos.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all orders");
                throw;
            }
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Pedidos.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting order with ID {id}");
                throw;
            }
        }

        public async Task AddAsync(Pedido pedido)
        {
            try
            {
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding a new order");
                throw;
            }
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
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
                var pedido = await _context.Pedidos.FindAsync(id);
                if (pedido == null)
                {
                    _logger.LogWarning($"Order with ID {id} not found for deletion.");
                    throw new KeyNotFoundException("Order not found");
                }
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing order with ID {id}");
                throw;
            }
        }
    }
}
