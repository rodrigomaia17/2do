using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace _2do.Data.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Edit(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}