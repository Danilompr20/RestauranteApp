using RestauranteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Service.Interfaces
{
     public interface IOrderService
    {
        PedidoViewModel Add(PedidoViewModel pedidoViewModel);
    }
}
