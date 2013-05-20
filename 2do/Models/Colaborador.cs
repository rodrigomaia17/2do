using System;
using System.Linq;
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

    public class ColaboradorInfo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public override string ToString()
        {
            return Nome;
        }
    }

    public static class ColaboradorExtensions
    {
        public static IQueryable<ColaboradorInfo> ToListColaboradorInfo(this IQueryable<Colaborador> lista)
        {
            return from c in lista select new ColaboradorInfo {Id = c.Id, Nome = c.Nome};
        } 
    }
}