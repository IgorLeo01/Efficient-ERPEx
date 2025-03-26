using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain
{
    public interface IItemPedidoRepository
    {
        Task<IEnumerable<ItemPedido>> GetAllAsync();
        Task<ItemPedido> GetByIdAsync(int id);
        Task AddAsync(ItemPedido itemPedido);
        Task UpdateAsync(ItemPedido itemPedido);
        Task DeleteAsync(int id);
    }
}
