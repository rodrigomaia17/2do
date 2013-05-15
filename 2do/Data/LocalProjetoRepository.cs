using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MongoDB.Bson;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data
{
    public class LocalProjetoRepository : IProjetoRepository 
    {
        private readonly Dictionary<int,Projeto> _projetos = new Dictionary<int, Projeto>();  

        public void Insert(Projeto entity)
        {
            _projetos.Add(entity.Id,entity);
        }

        public void Delete(Projeto entity)
        {
            _projetos.Remove(entity.Id);
        }
        public void Edit(Projeto entity)
        {
            _projetos[entity.Id] = entity;
        }
        
        public IQueryable<Projeto> GetAll()
        {
            return _projetos.Values.AsQueryable();
        }

        public Projeto GetById(int id)
        {
            return _projetos[id];
        }
    }
}