using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace _2do.Models
{
    public class Tarefa : AbstractModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public ColaboradorInfo Responsavel { get; private set; }

        public void AdicionarColaborador(Colaborador colaborador)
        {
            Responsavel = new ColaboradorInfo {Id = colaborador.Id, Nome = colaborador.Nome};
        }


        public void ConcluirTarefa()
        {
            DataFinalizacao = DateTime.Now;
        }
    }

    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(t => t.Responsavel).NotNull();
        }
    }
}