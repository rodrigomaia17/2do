using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data
{
    public class MongoDbProjetoRepository : IProjetoRepository 
    {
        public void Insert(Projeto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Projeto entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Projeto> SearchFor(Expression<Func<Projeto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Projeto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Projeto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}