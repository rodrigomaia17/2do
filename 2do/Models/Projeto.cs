using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _2do.Models
{
    public class Projeto  : AbstractModel
    {
        private DateTime? _dataInicio;
        [BsonElement("Tarefas")]
        private IList<Tarefa> _tarefas; 

        public Guid Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [BsonRequired]
        public DateTime? DataInicio
        {
            get { return _dataInicio; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Data Inicio nao pode ser menor que data Atual", paramName: "DataInicio");
                _dataInicio = value;
            }
        }

        public IEnumerable<Tarefa> Tarefas { get { return _tarefas; } }

        public int Colaborador { get; set; }

        public void AdicionarTarefa(Tarefa item)
        {
            if(_tarefas == null)
                _tarefas = new List<Tarefa>();
            _tarefas.Add(item);
        }

        public void AdicionarTarefa(IEnumerable<Tarefa> tarefas)
        {
            foreach (var t in tarefas) 
                AdicionarTarefa(t);
        }
    }
}