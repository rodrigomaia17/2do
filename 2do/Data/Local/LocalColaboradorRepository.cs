using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data.Local
{
    internal class LocalColaboradorRepository : LocalCrudRepository<Colaborador>,IColaboradorRepository
    {
        public LocalColaboradorRepository()
        {
            var list = new List<Colaborador>
                {
                    new Colaborador() {Nome = "Colaborador Teste"},
                    new Colaborador() {Nome = "Colaborador Teste 2"}
                };
            foreach (var colaborador in list)
            {
                Insert(colaborador);
            }
        }
    }
}