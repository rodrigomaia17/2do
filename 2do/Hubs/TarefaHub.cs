using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace _2do.Hubs
{
    [HubName("tarefaHub")]
    public class TarefaHub : Hub
    {
    }
}