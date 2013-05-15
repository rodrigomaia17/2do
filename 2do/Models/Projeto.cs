using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace _2do.Models
{
    public class Projeto  : AbstractModel
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataInicio { get; set; }

        public IList<Tarefa> Tarefas { get; set; } 

        public ObjectId Colaborador { get; set; }
    }
}