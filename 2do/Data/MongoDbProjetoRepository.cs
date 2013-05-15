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
        private readonly MongoCollection<Projeto> _projetos = MongoDbHelper.GetDatabase().GetCollection<Projeto>("Projetos"); 

        public void Insert(Projeto entity)
        {
            _projetos.Insert(entity);
        }

        public void Edit(Projeto entity)
        {
            _projetos.Save(entity);
        }

        public void Delete(Guid id)
        {
            var query = Query<Projeto>.EQ(e => e.Id, id);
            _projetos.Remove(query);
        }

        public IQueryable<Projeto> SearchFor(Expression<Func<Projeto, bool>> predicate)
        {
            var query = Query<Projeto>.EQ(predicate,true);
            return _projetos.Find(query).AsQueryable();
        }

        public IQueryable<Projeto> GetAll()
        {
            return _projetos.FindAll().AsQueryable();
        }

        public Projeto GetById(Guid id)
        {
            var query = Query<Projeto>.EQ(e => e.Id, id);
            return _projetos.FindOne(query);
        }
    }
}