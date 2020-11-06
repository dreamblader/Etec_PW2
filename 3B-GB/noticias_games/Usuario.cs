using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj01
{
    public class Usuario
    {
        public int id
        {get; set;}

        public string name
        {get; set;}

        public string image
        {get; set;}

         public override string ToString()
        {
            return "Nome: "+name+
            "\nLink Imagem: "+image;
        }
    }
}
