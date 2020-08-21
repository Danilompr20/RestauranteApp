using RestauranteApp.Domain;
using RestauranteApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository
{
    public class TipoPratoRepository :ITipoPratoRepository
    {
        private IList<TipoPrato> _tipoPratos = new List<TipoPrato>();

        public TipoPratoRepository(IList<TipoPrato> TipoPratos)
        {
            _tipoPratos = TipoPratos;
        }

        public TipoPratoRepository()
        {
            _tipoPratos.Add(new TipoPrato
            {
                Id = 1,
                Descricao = "Entrada",
                Ordem = 1
            }) ;

            _tipoPratos.Add(new TipoPrato
            {
                Id = 2,
                Descricao = "Prato Principal",
                Ordem = 2
            });

            _tipoPratos.Add(new TipoPrato
            {
                Id = 3,
                Descricao = "Bebida",
                Ordem = 3
            });

            _tipoPratos.Add(new TipoPrato
            {
                Id = 4,
                Descricao = "Sobremesa",
                Ordem = 4
            });
        }

        public IList<TipoPrato> GetAll()
        {
            return _tipoPratos;
        }
    }
}
