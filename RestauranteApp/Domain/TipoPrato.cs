using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Domain
{
    public class TipoPrato
    {
        public int Id { get; set; }

        public string Descricao { get; set; }
        public int Ordem { get; set; }
    }
}
