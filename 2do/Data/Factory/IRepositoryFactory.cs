using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2do.Data.Interfaces;

namespace _2do.Data.Factory
{
    public interface IRepositoryFactory
    {
        IProjetoRepository getProjetoRepository();
        IColaboradorRepository getColaboradorRepository();
    }
}