using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data.MongoDb
{
    internal class MongoDbColaboradorRepository : MongoDbCrudRepository<Colaborador> , IColaboradorRepository
    {
        public MongoDbColaboradorRepository() : base("Colaboradores")
        {
        }
    }
}