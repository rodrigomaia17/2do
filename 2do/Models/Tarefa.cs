using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2do.Models
{
    public class Tarefa : AbstractModel
    {
        public string Descricao { get; set; }
        public DateTime? DataFinalizacao { get; private set; }


        public void ConcluirTarefa()
        {
            DataFinalizacao = DateTime.Now;
        }
    }
}