using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_LiteDB
{
    internal class Pessoa
    {

        public Pessoa(string nome, int idade) 
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Fecha = DateTime.Now;
        } 

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public DateTime Fecha { get; set; }
    }
}
