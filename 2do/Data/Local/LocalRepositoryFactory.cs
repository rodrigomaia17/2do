using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2do.Data.Factory;
using _2do.Data.Interfaces;

namespace _2do.Data.Local
{
    public class LocalRepositoryFactory : IRepositoryFactory
    {
        private IProjetoRepository _projetoRepository;
        private IColaboradorRepository _colaboradorRepository;

        public IProjetoRepository getProjetoRepository()
        {
            return _projetoRepository ?? (_projetoRepository = new LocalProjetoRepository());
        }

        public IColaboradorRepository getColaboradorRepository()
        {
            return _colaboradorRepository ?? (_colaboradorRepository = new LocalColaboradorRepository());
        }
    }
}