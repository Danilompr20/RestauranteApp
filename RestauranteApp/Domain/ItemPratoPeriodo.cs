using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Domain
{
    public class OpcaoPratoPeriodo
    {
        public int Id { get; set; }

        public int ItemPratoId { get; set; }

        public int PeriodoId { get; set; }

        public ItemPrato ItemPrato { get; set; }

        public Periodo  Periodo { get; set; }

        public int? QtdMaxima { get; set; }
    }
}
