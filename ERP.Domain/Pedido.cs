using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;
        public List<ItemPedido> Itens { get; set; } = new();
        public double Total => Itens.Sum(i => i.Quantidade * i.Produto.Preco);
    }
}
