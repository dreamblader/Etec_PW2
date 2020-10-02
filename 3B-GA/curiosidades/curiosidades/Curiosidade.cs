using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj01
{
    public class Curiosidade
    {
        public string titulo
        { get; set; }

        public string descricao
        { get; set; }

        public override string ToString()
        {
            return "Titulo: " + this.titulo + "\nDescrição: " + this.descricao;
        }
    }
}
