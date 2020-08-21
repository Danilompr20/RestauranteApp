using RestauranteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        IList<Pedido> GetAll();


       void Add(Pedido pedido);
        
    }
}
