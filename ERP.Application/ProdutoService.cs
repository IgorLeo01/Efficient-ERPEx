using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ERP.Application
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ProdutoService> _logger;

        public ProdutoService(IProdutoRepository produtoRepository, ILogger<ProdutoService> logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            try
            {
                return await _produtoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all products");
                throw;
            }
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            try
            {
                return await _produtoRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching product with ID {id}");
                throw;
            }
        }

        public async Task AddAsync(Produto produto)
        {
            try
            {
                await _produtoRepository.AddAsync(produto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product");
                throw;
            }
        }

        public async Task UpdateAsync(Produto produto)
        {
            try
            {
                await _produtoRepository.UpdateAsync(produto);
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
                await _produtoRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product with ID {id}");
                throw;
            }
        }
    }
}
