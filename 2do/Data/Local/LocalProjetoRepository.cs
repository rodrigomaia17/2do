using System;
using System.Collections.Generic;
using System.Linq;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data.Local
{
    internal class LocalProjetoRepository : LocalCrudRepository<Projeto> , IProjetoRepository 
    {
        
    }
}