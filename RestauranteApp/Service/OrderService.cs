using RestauranteApp.Domain;
using RestauranteApp.Models;
using RestauranteApp.Repository;
using RestauranteApp.Repository.Interfaces;
using RestauranteApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Service
{


    public class OrderService : IOrderService
    {
        private readonly IItemPratoRepository _itemPratoRepository;
        private readonly ITipoPratoRepository _tipoPratoRepository;
        private readonly IPeriodoRepository _periodoRepository;
        private readonly IItemPratoPeriodoRepository _itemPratoPeriodoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public OrderService(IItemPratoRepository itemPratoRepository, ITipoPratoRepository tipoPratoRepository,
            IPedidoRepository pedidoRepository,
            IItemPratoPeriodoRepository itemPratoPeriodoRepository,
            IPeriodoRepository periodoRepository)
        {
            _itemPratoRepository = itemPratoRepository;
            _tipoPratoRepository = tipoPratoRepository;
            _periodoRepository = periodoRepository;
            _itemPratoPeriodoRepository = itemPratoPeriodoRepository;
            _pedidoRepository = pedidoRepository;
        }


        public PedidoViewModel Add(PedidoViewModel pedidoViewModel)
        {
            //string pedidoViewModel = "Manhã, 1, 2, 3, 3, 3";
            if (string.IsNullOrEmpty(pedidoViewModel.Entrada))
            {
                pedidoViewModel.Saida = "erro";
                pedidoViewModel.Errors.Add(new PedidoErrorViewModel() { Message = "Pedido não pode ser vazio ", Name = "Entrada" });
                pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll();
                return pedidoViewModel;
            }
            var order = pedidoViewModel.Entrada.Split(",");

            //verificar se período existe;
            var entradaPeriodoDescricao = order[0].ToLower();
            //buscando o periodo igual ao informado
            var periodo = _periodoRepository.GetAll().FirstOrDefault(x => x.Descricao.ToLower() == entradaPeriodoDescricao);
            if (periodo == null)
            {
                pedidoViewModel.Saida = "erro";
                pedidoViewModel.Errors.Add(new PedidoErrorViewModel() { Message = "Perido Invalido", Name = "Entrada" });
                pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll();
                return pedidoViewModel;
            }

            //var digitos = string.Join("", order.Skip(1)).ToCharArray();
            //if (!digitos.All(x=> char.IsDigit(x)))
            //{
            //    pedidoViewModel.Saida = "erro";
            //    pedidoViewModel.Errors.Add(new PedidoErrorViewModel() { Message = "Perido Invalido", Name = "Entrada" });
            //    pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll();
            //    return pedidoViewModel;
            //}
            var itens = order.Skip(1).Select(x => Convert.ToInt32(x));

            if (!itens.Any())
            {
                pedidoViewModel.Saida = "erro";
                pedidoViewModel.Errors.Add(new PedidoErrorViewModel() { Message = "Adicione ao menos um item", Name = "Entrada" });
                pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll();
                return pedidoViewModel;
            }

            var itensCadastrados = _itemPratoRepository.GetAll();

            int itemNaoEncontrado = itens.FirstOrDefault(x => !itensCadastrados.Any(y => y.Id == x));

            if (itemNaoEncontrado > 0)
            {
                pedidoViewModel.Saida = "erro";
                pedidoViewModel.Errors.Add(new PedidoErrorViewModel() { Message = $"Item {itemNaoEncontrado} não encontrado.", Name = "Entrada" });
                pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll();
                return pedidoViewModel;
            }

            var (success, saida) = GetSaidaPedido(periodo, itens);

            pedidoViewModel.Saida =  saida;

            if (success)
            {
                _pedidoRepository.Add(new Pedido
                {
                    DataPedido = DateTime.Now,
                    Entrada = pedidoViewModel.Entrada,
                    Saida = pedidoViewModel.Saida
                });
            }
            else
            {
                pedidoViewModel.Errors.Add(new PedidoErrorViewModel()
                {
                   Name = "Entrada",
                   Message = "Itens não atende os requisitos"
                });
            }

            pedidoViewModel.HistoricoPedidos = _pedidoRepository.GetAll();

            return pedidoViewModel;
        }

        private (bool, string) GetSaidaPedido(Periodo periodo, IEnumerable<int> ItensId)
        {
            IDictionary<int, string> itensStatus = new Dictionary<int, string>();

            foreach (var itemId in ItensId)
            {
                var item = _itemPratoRepository.GetById(itemId);

                var itemPeriodo = _itemPratoPeriodoRepository.GetOpcaoPratoPeriodoById(periodo.Id, itemId);

                if (itemPeriodo == null)
                {
                    if (itensStatus.ContainsKey(itemId))
                        itensStatus[itemId] = "erro";
                    else
                    {
                        itensStatus.Add(itemId, "erro");
                    }

                    break;
                }
                
                //Contar quantos id's com o valor 1 foram informados
                var totalItensAtual = ItensId.Where(x => x == itemId).Count();
                
                //Ultrapassou o limite do item informado
                if (itemPeriodo.QtdMaxima.HasValue && totalItensAtual > itemPeriodo.QtdMaxima.Value)
                {
                    if (itensStatus.ContainsKey(itemId))
                        itensStatus[itemId] = "erro";
                    else
                        itensStatus.Add(itemId, "erro");

                    break;
                }
                else
                {
                    if (!itensStatus.ContainsKey(itemId))
                    {
                        if (totalItensAtual > 1)
                            itensStatus.Add(itemId, $"{item.Descricao}(x{totalItensAtual})");
                        else
                            itensStatus.Add(itemId, $"{item.Descricao}");
                    }
                }
            }


            //
            var list = itensStatus.ToList().Select(x => new { Item = _itemPratoRepository.GetById(x.Key), Descricao = x.Value });

            var result = list.OrderBy(x => x.Item.TipoPrato.Ordem);

            return (!list.Any(x => x.Descricao == "erro"), string.Join(", ", result.Select(x => x.Descricao)));
        }
    }
}
