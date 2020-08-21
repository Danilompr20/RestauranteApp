using RestauranteApp.Domain;
using RestauranteApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository
{
    public class ItemPratoRepository :IItemPratoRepository
    {
        private IList<ItemPrato> _itensPrato = new List<ItemPrato>();

        public ItemPratoRepository(IList<ItemPrato> ItensPrato)
        {
            _itensPrato = ItensPrato;
        }

        public ItemPratoRepository()
        {
            _itensPrato.Add(new ItemPrato
            {
                Id = 1,
                Descricao = "Ovos",
                TipoPratoId = 1,
                TipoPrato = new TipoPrato
                {
                    Id  = 1,
                    Descricao = "Entrada"
                }
            });

            _itensPrato.Add(new ItemPrato
            {
                Id = 2,
                Descricao = "Bife",
                TipoPratoId = 1,
                TipoPrato = new TipoPrato
                {
                    Id = 1,
                    Descricao = "Entrada"
                }
            });

            _itensPrato.Add(new ItemPrato
            {
                Id = 3,
                Descricao = "Torradas",
                TipoPratoId = 2,
                TipoPrato = new TipoPrato
                {
                    Id = 2,
                    Descricao = "Prato Principal"
                }
            });
            _itensPrato.Add(new ItemPrato
            {
                Id = 4,
                Descricao = "Batatas",
                TipoPratoId = 2,
                TipoPrato = new TipoPrato
                {
                    Id = 2,
                    Descricao = "Prato Principal"
                }
            });
            _itensPrato.Add(new ItemPrato
            {
                Id = 5,
                Descricao = "Café",
                TipoPratoId = 3,
                TipoPrato = new TipoPrato
                {
                    Id = 3,
                    Descricao = "Bebidas"
                }
            });

            _itensPrato.Add(new ItemPrato
            {
                Id = 6,
                Descricao = "Vinho",
                TipoPratoId = 3,
                TipoPrato = new TipoPrato
                {
                    Id = 3,
                    Descricao = "Bebidas"
                }
            });

            _itensPrato.Add(new ItemPrato
            {
                Id = 7,
                Descricao = "Bolo",
                TipoPratoId = 4,
                TipoPrato = new TipoPrato
                {
                    Id = 4,
                    Descricao = "Sobremesa"
                }
            });
        }

        public IList<ItemPrato> GetAll()
        {
            return _itensPrato;
        }

        public ItemPrato GetById(int id)
        {
            return _itensPrato.FirstOrDefault(x => x.Id == id);
        }
    }
}
