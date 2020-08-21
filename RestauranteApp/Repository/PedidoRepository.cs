using RestauranteApp.Domain;
using RestauranteApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository
{
    public class PedidoRepository :IPedidoRepository
    {
        private IList<Pedido> _pedidos = new List<Pedido>();
        public PedidoRepository(IList<Pedido> Pedidos)
        {
            _pedidos = Pedidos;

        }

        public PedidoRepository()
        {
            
        }

        public IList<Pedido> GetAll()
        {
            return _pedidos;
        }

        public void Add(Pedido pedido)
        {
            _pedidos.Add(pedido);
        }
    }
}
