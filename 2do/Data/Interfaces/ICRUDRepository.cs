using System;
using System.Linq;

namespace _2do.Data.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : IPossuiGuidId
    {
        void Insert(TEntity entity);
        void Edit(TEntity entity);
        void Delete(Guid id);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}