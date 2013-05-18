using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2do.Models;

namespace _2do.Tests
{
    public static class ColaboradorUtil
    {
        public static Colaborador NovoColaborador()
        {
            return new Colaborador() {Cargo = "CargoTeste", Matricula = "MatriculaTeste", Nome = "NomeTeste"};
        }
    }
}
