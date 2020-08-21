using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Domain;
using RestauranteApp.Models;
using RestauranteApp.Repository.Interfaces;
using RestauranteApp.Service.Interfaces;

namespace RestauranteApp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IOrderService _orderService;
         private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IOrderService orderService, IPedidoRepository pedidoRepository)
        {
            _orderService = orderService;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult Index(string entrada, string saida)
        {
            if (entrada != null || saida != null)
            {
                var pedidoViewModel = new PedidoViewModel() { Entrada = entrada , Saida = saida};
                pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll().OrderBy(x => x.DataPedido).ToList();
                return View(pedidoViewModel);

            }
            else
            {
                var pedidoViewModel = new PedidoViewModel();
                pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll().OrderBy(x => x.DataPedido).ToList();
                return View(pedidoViewModel);
            }
            
            
        }

        
        [HttpPost]
        public IActionResult Enviar(PedidoViewModel pedidoViewModel)
        {
            //Manhã, Ovos, Torradas, Café
            var result = _orderService.Add(pedidoViewModel);

            if (!result.Success)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Name, item.Message);
                }
               
            }

            // passando para variavel pedido que esta na action index o valor de result
            return RedirectToAction("Index", new { entrada = result.Entrada, saida = result.Saida});
           // return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
