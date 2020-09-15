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
        public string nome
        {get; set;}

        public string cidade
        {get; set;}

        public string pais
        {get; set;}

        public string linkMaps
        { get; set; }

        public string descricao
        { get; set; }

        public bool foiRevisado
        { get; set; }

    }
}
