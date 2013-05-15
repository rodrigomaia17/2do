using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace _2do.Models
{
    public class Projeto  : AbstractModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        public IList<Tarefa> Tarefas { get; set; }

        public int Colaborador { get; set; }
    }
}