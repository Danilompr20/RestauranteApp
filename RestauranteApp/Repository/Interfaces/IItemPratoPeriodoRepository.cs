﻿using RestauranteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteApp.Repository.Interfaces
{
   public  interface IItemPratoPeriodoRepository
    {
         IList<OpcaoPratoPeriodo> GetAll();
       
        OpcaoPratoPeriodo GetOpcaoPratoPeriodoById(int periodoId, int itemId);
       
    }
}
