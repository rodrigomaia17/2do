using System;
using _2do.Data.Interfaces;

namespace _2do.Models
{
    public class Colaborador : AbstractModel ,IPossuiGuidId
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cargo { get; set; }
    }
}