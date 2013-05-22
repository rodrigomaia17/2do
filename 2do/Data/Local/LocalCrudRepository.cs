using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2do.Data.Interfaces;

namespace _2do.Data.Local
{
    internal abstract class LocalCrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : IPossuiGuidId 
    {
        protected static readonly Dictionary<Guid, TEntity> _colecao = new Dictionary<Guid, TEntity>();

        public void Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _colecao.Add(entity.Id, entity);
        }

        public void Delete(Guid id)
        {
            _colecao.Remove(id);
        }
        public void Edit(TEntity entity)
        {
            _colecao[entity.Id] = entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _colecao.Values.AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            return _colecao[id];
        }
    }
}