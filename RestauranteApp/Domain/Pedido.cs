using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Domain
{
    public class Pedido
    {
     
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
