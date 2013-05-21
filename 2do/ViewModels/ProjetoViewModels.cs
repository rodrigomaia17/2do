using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2do.Models;

namespace _2do.ViewModels
{
    public class ProjetoFormViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required, DataType(DataType.Date)]
        public string DataEntrega { get; set; }
        [Required, DataType(DataType.Date)]
        public string DataInicio { get; set; }
        [Display(Name = "Responsavel")]
        public Guid ResponsavelId { get; set; }

        public SelectList ResponsaveisList { get; set; }

        public ProjetoFormViewModel()
        {
            
        }
        public ProjetoFormViewModel(Projeto p,IEnumerable<Colaborador> colaboradores )
        {
            var culture = new CultureInfo("pt-BR");
            Nome = p.Nome;
            DataEntrega = (p.DataEntrega == default(DateTime) ? DateTime.Today : p.DataEntrega).ToString("d",culture);
            DataInicio = (p.DataInicio == default(DateTime) ? DateTime.Today : p.DataInicio).ToString("d",culture);
            ResponsavelId = p.Responsavel != null ? p.Responsavel.Id : Guid.Empty;

             ResponsaveisList = new SelectList(colaboradores, "Id", "Nome");
        }

        public void ToProjeto(Projeto p)
        {
            var culture = new CultureInfo("pt-BR");
            p.Nome = Nome;
            p.DataInicio = DateTime.Parse(DataInicio, culture);
            p.DataEntrega = DateTime.Parse(DataEntrega, culture);
        }
    }

    public class ProjetoListViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DataEntrega { get; set; }
        public string DataInicio { get; set; }
        public string Responsavel { get; set; }

        public ProjetoListViewModel(Projeto projeto)
        {
            Id = projeto.Id;
            Nome = projeto.Nome;
            DataEntrega = projeto.DataEntrega == default(DateTime) ? DateTime.Today.ToShortDateString() : projeto.DataEntrega.ToShortDateString();
            DataInicio = projeto.DataInicio ==  default(DateTime) ? DateTime.Today.ToShortDateString() : projeto.DataInicio.ToShortDateString();
            Responsavel = projeto.Responsavel.Nome;

        }
    }

    public class ProjetoDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DataEntrega { get; set; }
        public IEnumerable<TarefasListViewModel> Tarefas { get; set; }

        public ProjetoDetailsViewModel(Projeto projeto)
        {
            Id = projeto.Id;
            Nome = projeto.Nome;
            DataEntrega = projeto.DataEntrega == default(DateTime) ? DateTime.Today.ToShortDateString() : projeto.DataEntrega.ToShortDateString();
            
            Tarefas = (from t in projeto.Tarefas.Values select new TarefasListViewModel(t)).ToList();
        }
    }
}