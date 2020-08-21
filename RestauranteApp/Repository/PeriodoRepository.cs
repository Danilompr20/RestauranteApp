using RestauranteApp.Domain;
using RestauranteApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository
{
    public class PeriodoRepository :IPeriodoRepository
    {
        private IList<Periodo> _periodos = new List<Periodo>();

        public PeriodoRepository(IList<Periodo> Periodos)
        {
            _periodos = Periodos;
        }

        public PeriodoRepository()
        {
            _periodos.Add(new Periodo
            {
                Id = 1,
                Descricao = "Manhã"
            });

            _periodos.Add(new Periodo
            {
                Id = 2,
                Descricao = "Noite"
            });
        }

        public IList<Periodo> GetAll()
        {
            return _periodos;
        }
    }
}
