using RestauranteApp.Domain;
using RestauranteApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository
{
    public class ItemPratoPeriodoRepository :IItemPratoPeriodoRepository
    {
        private IList<OpcaoPratoPeriodo> _itemPratoPeriodos = new List<OpcaoPratoPeriodo>();

        public ItemPratoPeriodoRepository(IList<OpcaoPratoPeriodo> ItemPratoPeriodos)
        {
            _itemPratoPeriodos = ItemPratoPeriodos;
        }

        public ItemPratoPeriodoRepository()
        {
            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
               Id = 1,
               ItemPratoId = 1, //Ovos
               PeriodoId = 1, //Manhã
               ItemPrato = new ItemPrato
               {
                   Id = 1,
                   Descricao = "Ovos",
                   TipoPrato = new TipoPrato
                   {
                      Id = 1,
                      Descricao = "Entrada"
                   }
               },
               Periodo = new Periodo
               {
                   Id = 1,
                   Descricao = "Manhã"
               },
               QtdMaxima = 1
            });


            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
                Id = 2,
                ItemPratoId = 2, //Bife
                PeriodoId = 2, //Noite
                ItemPrato = new ItemPrato
                {
                    Id = 2,
                    Descricao = "Bife",
                    TipoPrato = new TipoPrato
                    {
                        Id = 2,
                        Descricao = "Prato Principal"
                    }
                },
                Periodo = new Periodo
                {
                    Id = 2,
                    Descricao = "Noite"
                },
                QtdMaxima = 1


            });

            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
                Id = 3,
                ItemPratoId = 3, //Torradas
                PeriodoId = 1, //Manhã
                ItemPrato = new ItemPrato
                {
                    Id = 3,
                    Descricao = "Torradas",
                    TipoPrato = new TipoPrato
                    {
                        Id = 2,
                        Descricao = "Prato Principal"
                    }
                },
                Periodo = new Periodo
                {
                    Id = 1,
                    Descricao = "Manhã"
                },
                QtdMaxima = 1
            });

            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
                Id = 4,
                ItemPratoId = 4, //Batatas
                PeriodoId = 2, //Noite
                ItemPrato = new ItemPrato
                {
                    Id = 4,
                    Descricao = "Batatas",
                    TipoPrato = new TipoPrato
                    {
                        Id = 2,
                        Descricao = "Prato Principal"
                    }
                },
                Periodo = new Periodo
                {
                    Id = 2,
                    Descricao = "Noite"
                },
                QtdMaxima = null
            });

            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
                Id = 5,
                ItemPratoId = 5, //Café
                PeriodoId = 1, //Manhã
                ItemPrato = new ItemPrato
                {
                    Id = 5,
                    Descricao = "Café",
                    TipoPrato = new TipoPrato
                    {
                        Id = 3,
                        Descricao = "Bebida"
                    }
                },
                Periodo = new Periodo
                {
                    Id = 1,
                    Descricao = "Manhã"
                },
                QtdMaxima = null
            });

            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
                Id = 6,
                ItemPratoId = 6, //Vinho
                PeriodoId = 2, //Noite
                ItemPrato = new ItemPrato
                {
                    Id = 6,
                    Descricao = "Vinho",
                    TipoPrato = new TipoPrato
                    {
                        Id = 3,
                        Descricao = "Bebida"
                    }
                },
                Periodo = new Periodo
                {
                    Id = 2,
                    Descricao = "Noite"
                },
                QtdMaxima = 1
            });

            _itemPratoPeriodos.Add(new OpcaoPratoPeriodo
            {
                Id = 7,
                ItemPratoId = 7, //Bolo
                PeriodoId = 2, //Noite
                ItemPrato = new ItemPrato
                {
                    Id = 7,
                    Descricao = "Bolo",
                    TipoPrato = new TipoPrato
                    {
                        Id = 7,
                        Descricao = "Sobremesa"
                    }
                },
                Periodo = new Periodo
                {
                    Id = 2,
                    Descricao = "Noite"
                },
                QtdMaxima = 1
            }); 
        }

        public IList<OpcaoPratoPeriodo> GetAll()
        {
            return _itemPratoPeriodos;
        }

        public OpcaoPratoPeriodo GetOpcaoPratoPeriodoById(int periodoId, int itemId)
        {
            return _itemPratoPeriodos.Where(x => x.PeriodoId == periodoId && x.ItemPratoId == itemId).SingleOrDefault();
        }
    }
}
