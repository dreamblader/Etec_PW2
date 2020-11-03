using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Policy;

namespace proj01
{
    public class Usuario
    {

        public int id 
        {get; set;}
        
        public string nome
        { get; set; }

        public string imagem
        { get; set; }

        public string bio
        { get; set; }

        public int pontos
        { get; set; }

        public override string ToString()
        {
            return "Nome: " + this.nome + "\nBio: " + this.bio + "\nPontos" +  this.pontos;
        }
    }
}
