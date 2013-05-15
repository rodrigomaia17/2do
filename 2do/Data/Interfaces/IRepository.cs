using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace _2do.Data.Interfaces
{
    public interface IRepository<TId,TEntity>
    {
        void Insert(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TId id);
        IQueryable<TEntity> GetAll();
        TEntity GetById(TId id);
    }
}