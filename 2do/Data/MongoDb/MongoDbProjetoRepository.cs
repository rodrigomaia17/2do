using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data.MongoDb
{
    internal class MongoDbProjetoRepository : MongoDbCrudRepository<Projeto> ,IProjetoRepository
    {
        public MongoDbProjetoRepository() : base("Projetos")
        {
        }
    }
}