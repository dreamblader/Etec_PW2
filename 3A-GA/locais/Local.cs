using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace site
{
    public class Local
    {
        public int id
        {get; set;}

        public string nome
        {get; set;}

        public string cidade
        {get; set;}

        public string pais
        {get; set;}

        public string imagem
        { get; set; }

        public string linkMaps
        { get; set; }

        public string descricao
        { get; set; }

        public bool foiRevisado
        { get; set; }

        public Local()
        {
            linkMaps = "";
            foiRevisado = false;
        }

        public override string ToString()
        {
            return base.ToString() + ":" +
                "\n Nome: " + nome +
                "\n Cidade: " + cidade +
                "\n Pais: " + pais +
                "\n Link Imagem: " + imagem +
                "\n Link Maps: " + linkMaps +
                "\n Descrição: " + descricao +
                "\n Foi Revisado?: " + foiRevisado.ToString();
        }
    }
}
