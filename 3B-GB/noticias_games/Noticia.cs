using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj01
{
    public class Noticia
    {
        public string titulo
        { get; set; }

        public string jogo
        { get; set; }

        public string imagem
        { get; set; }

        public string descricao
        { get; set; }

        public override string ToString()
        {
            return "Titulo: "+titulo+
            "\nJogo: "+jogo+
            "\nLink Imagem: "+imagem+
            "\nDescricao: "+descricao;
        }
        //public CATEGORIA categoria; 
    }
}
