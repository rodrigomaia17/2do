using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2do.Data.Factory;
using _2do.Data.Interfaces;

namespace _2do.Data.MongoDb
{
    public class MongoRepositoryFactory : IRepositoryFactory
    {
        public IProjetoRepository getProjetoRepository()
        {
            return new MongoDbProjetoRepository();
        }

        public IColaboradorRepository getColaboradorRepository()
        {
            return new MongoDbColaboradorRepository();
        }
    }
}