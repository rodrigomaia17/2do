using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using _2do.Data.Interfaces;

namespace _2do.Data.MongoDb
{
    internal abstract class MongoDbCrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : IPossuiGuidId
    {
        private readonly MongoCollection<TEntity> _collection;

        protected MongoDbCrudRepository(string nomeCollection)
        {
           _collection  = MongoDbHelper.GetDatabase().GetCollection<TEntity>(nomeCollection);
        }

        public void Insert(TEntity entity)
        {
            _collection.Insert(entity);
        }

        public void Edit(TEntity entity)
        {
            _collection.Save(entity);
        }

        public void Delete(Guid id)
        {
            var query = Query<TEntity>.EQ(e => e.Id, id);
            _collection.Remove(query);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Query<TEntity>.EQ(predicate, true);
            return _collection.Find(query).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _collection.FindAll().AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            var query = Query<TEntity>.EQ(e => e.Id, id);
            return _collection.FindOne(query);
        }
    }
}