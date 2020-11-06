using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace site
{
    public class Usuario
    {
        public int id
        {get; set;}

        public string nome
        {get; set;}

        public string imagem
        {get; set;}

        public string bio
        {get; set;}


        public override string ToString()
        {
            return base.ToString() + ":" +
                "\n ID: " + id +
                "\n Nome: " + nome +
                "\n Bio: " + bio +
                "\n Link Imagem: " + imagem;
        }
    }
}