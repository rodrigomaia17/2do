using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using _2do.Data.Factory;
using _2do.Data.Interfaces;
using _2do.Hubs;
using _2do.Models;
using _2do.ViewModels;

namespace _2do.Controllers
{
    public class TarefaController : ApiControllerWithHub<TarefaHub>
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IColaboradorRepository _colaboradorRepository;

        Lazy<IHubContext> _tarefaHub = new Lazy<IHubContext>(
           () => GlobalHost.ConnectionManager.GetHubContext<TarefaHub>()
       );

        Lazy<IHubContext> _notificacaoHub = new Lazy<IHubContext>(
           () => GlobalHost.ConnectionManager.GetHubContext<NotificacaoHub>()
       );
       

         public TarefaController(IRepositoryFactory repository)
        {
            _projetoRepository = repository.getProjetoRepository();
            _colaboradorRepository = repository.getColaboradorRepository();
        }

    
        public IEnumerable<Tarefa> Get(Guid idProjeto)
        {
            return _projetoRepository.GetById(idProjeto).Tarefas.Values;
        } 

        // GET api/tarefaapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tarefaapi
        [HttpPost]
        public void Post(TarefaFormViewModel tarefaVM)
        {
            var projeto = _projetoRepository.GetById(tarefaVM.IdProjeto);

            var tarefa = new Tarefa();
            tarefaVM.ToTarefa(tarefa);

            tarefa.AdicionarColaborador(_colaboradorRepository.GetById(tarefaVM.ResponsavelId));
            tarefa.CreatedAt = DateTime.Today;

            projeto.Tarefas.Add(tarefa);

            _projetoRepository.Edit(projeto);

            _tarefaHub.Value.Clients.All.addTarefa(tarefa);
            _notificacaoHub.Value.Clients.All.sucesso("","Tarefa Adicionada");
        }

        // PUT api/tarefaapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tarefaapi/5
        public void Delete(int id)
        {
        }
    }
}
