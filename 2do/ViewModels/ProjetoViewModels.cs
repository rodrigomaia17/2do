using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2do.Models;

namespace _2do.ViewModels
{
    public class ProjetoFormViewModel
    {
        [Required, DataType(DataType.Date)]
        public string Nome { get; set; }
        [Required, DataType(DataType.Text)]
        public DateTime DataEntrega { get; set; }
        [Required, DataType(DataType.Text)]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Responsavel")]
        public Guid ResponsavelId { get; set; }

        public SelectList ResponsaveisList { get; set; }

        public ProjetoFormViewModel()
        {
            
        }
        public ProjetoFormViewModel(Projeto p,IEnumerable<Colaborador> colaboradores )
        {
            Nome = p.Nome;
            DataEntrega = p.DataEntrega;
            DataInicio = p.DataInicio ?? DateTime.Today;
            ResponsavelId = p.Responsavel != null ? p.Responsavel.Id : Guid.Empty;

             ResponsaveisList = new SelectList(colaboradores, "Id", "Nome");
        }

        public void ToProjeto(Projeto p)
        {
            p.Nome = Nome;
            p.DataInicio = DataInicio;
            p.DataEntrega = DataEntrega;
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
            DataEntrega = projeto.DataEntrega.ToShortDateString();
            DataInicio = projeto.DataInicio.HasValue ? projeto.DataInicio.Value.ToShortDateString() : "";
            Responsavel = projeto.Responsavel.Nome;

        }
    }
}