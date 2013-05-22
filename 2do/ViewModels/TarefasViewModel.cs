using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridMvc.DataAnnotations;
using _2do.Models;

namespace _2do.ViewModels
{
    public class TarefasListViewModel
    {

        public Guid Id { get; set; }

        [GridColumn(Title = "Descrição")]
        public string Descricao { get; set; }

        [GridColumn(Title = "Responsável")]
        public string Responsavel { get; set; }
        [GridHiddenColumn]
        public Guid ResponsavelId { get; set; }

        [GridColumn(Title = "Data de Criação", Format = "{0:dd/MM/yyyy}")]
        public string DataCriacao { get; set; }

        [GridColumn(Title = "Data de Conclusao", Format = "{0:dd/MM/yyyy}")]
        public string DataConclusao { get; set; }

        [NotMappedColumnAttribute]
        public bool Concluida { get; set; }
        

        public TarefasListViewModel()
        {
            
        }
        

    
        

        public TarefasListViewModel(Tarefa tarefa)
        {
            var culture = new CultureInfo("pt-BR");

            Id = tarefa.Id;
            Descricao = tarefa.Descricao;
            Responsavel = tarefa.Responsavel.Nome;
            ResponsavelId = tarefa.Responsavel.Id;
            DataCriacao = tarefa.CreatedAt.ToString("d",culture);
            DataConclusao = tarefa.DataFinalizacao.HasValue
                                ? tarefa.DataFinalizacao.Value.ToString("d", culture)
                                : string.Empty;
            Concluida = tarefa.DataFinalizacao.HasValue;
        }


    }

    public class TarefaFormViewModel
    {

        public Guid IdProjeto { get; set; }
        
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Responsavel")]
        public Guid ResponsavelId { get; set; }

        public SelectList ResponsaveisList { get; set; }

        public TarefaFormViewModel()
        {

        }
        public TarefaFormViewModel(Tarefa t,Guid idProjeto, IEnumerable<Colaborador> colaboradores)
        {
            Descricao = t.Descricao;
            IdProjeto = idProjeto;
            ResponsavelId = t.Responsavel != null ? t.Responsavel.Id : Guid.Empty;

            ResponsaveisList = new SelectList(colaboradores, "Id", "Nome");
        }

        public void ToTarefa(Tarefa t)
        {
            t.Descricao = Descricao;
        }
    }
}