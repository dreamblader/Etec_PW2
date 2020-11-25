using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj01
{
    public class Curiosidade
    {
        public Curiosidade()
        {
            id = -1;
            titulo = "Curiosidade Inexistente";
            descricao = "Essa curiosidade foi acessada por um link errado, verifique sua página e navegação, qualquer duvida contate nosso suporte";
            reviewed = true;
            usuarioId = -1;
        }

        public int id
        { get; set; }

        public string titulo
        { get; set; }

        public string descricao
        { get; set; }

        public bool reviewed
        { get; set; }

        public int usuarioId
        { get; set; }

        public override string ToString()
        {
            return "Titulo: " + this.titulo + "\nDescrição: " + this.descricao;
        }
    }
}
