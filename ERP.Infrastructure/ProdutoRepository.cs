using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProdutoRepository> _logger;

        public ProdutoRepository(ApplicationDbContext context, ILogger<ProdutoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            try
            {
                return await _context.Produtos.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all products");
                throw;
            }
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Produtos.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting product with id: {id}");
                throw;
            }
        }

        public async Task AddAsync(Produto produto)
        {
            try
            {
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new product");
                throw;
            }
        }

        public async Task UpdateAsync(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found for deletion.");
                    throw new KeyNotFoundException("Product not found");
                }
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing product with ID {id}");
                throw;
            }
        }
    }
}
