using RestauranteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository.Interfaces
{
     public interface IItemPratoRepository
    {
        IList<ItemPrato> GetAll();


       ItemPrato GetById(int id);
       
    }
}
