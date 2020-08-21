using RestauranteApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Models
{
    public class PedidoViewModel
    {

 
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public IList<Pedido> HistoricoPedidos { get; set; }
        public IList<PedidoErrorViewModel> Errors { get; set; } = new List<PedidoErrorViewModel>();// ja cria assim que instancia classe
        public bool Success { get { return !Errors.Any(); } }
    }
   
    public class PedidoErrorViewModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
    }
}
