using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using _2do.Data.Interfaces;

namespace _2do.Models
{
    public class Projeto : AbstractModel, IPossuiGuidId
    {


        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrega { get; set; }

        public DateTime DataInicio { get; set; }

        public IDictionary<Guid, Tarefa> Tarefas { get; set; }


        public ColaboradorInfo Responsavel { get; private set; }



        public void AdicionarColaborador(Colaborador colaborador)
        {
            Responsavel = new ColaboradorInfo { Id = colaborador.Id, Nome = colaborador.Nome };
        }

        public Projeto()
        {
            Tarefas = new Dictionary<Guid, Tarefa>();

        }
    }

    public class ProjetoValidator : AbstractValidator<Projeto>
    {
        public ProjetoValidator()
        {
            RuleFor(p => p.DataInicio).NotNull().GreaterThanOrEqualTo(DateTime.Today);
        }
    }

    public static class ProjetoExtension
    {
        public static void Add(this IDictionary<Guid, Tarefa> dic, Tarefa tarefa)
        {
            if (tarefa.Id == Guid.Empty)
                tarefa.Id = Guid.NewGuid();
            dic.Add(tarefa.Id,tarefa);
        }
    }


}