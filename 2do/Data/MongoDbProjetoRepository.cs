using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data
{
    public class MongoDbProjetoRepository : IProjetoRepository
    {
        private readonly MongoCollection<Projeto> projetos = MongoDbHelper.GetDatabase().GetCollection<Projeto>("Projetos"); 

        public void Insert(Projeto entity)
        {
            projetos.Insert(entity);
        }

        public void Edit(Projeto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            var query = Query<Projeto>.EQ(e => e.Id, id);
            projetos.Remove(query);
        }

        public IQueryable<Projeto> SearchFor(Expression<Func<Projeto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Projeto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Projeto GetById(Guid id)
        {
            var query = Query<Projeto>.EQ(e => e.Id, id);
            return projetos.FindOne(query);
        }
    }
}