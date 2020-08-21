using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Domain
{
    public class ItemPrato
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int TipoPratoId { get; set; }

        public TipoPrato TipoPrato { get; set; }
    }
}
