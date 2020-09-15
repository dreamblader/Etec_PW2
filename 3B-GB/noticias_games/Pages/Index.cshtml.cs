using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace proj01.Pages
{
    public class IndexModel : PageModel
    {
        public string nome = "Noticias Gamers";
        public List<string> listaNoticias = new List<string>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            listaNoticias.Add("https://steamuserimages-a.akamaihd.net/ugc/1599295696742403449/7D41826BAE528E31EB15EF17D273CF0817E6DB93/");
            listaNoticias.Add("https://steamuserimages-a.akamaihd.net/ugc/1599295696741429862/D1E32E23B3497597ABAE311F240D878704307480/");
            listaNoticias.Add("https://steamuserimages-a.akamaihd.net/ugc/1478824043136420389/89AFEEBB849C093B84D4EAEB3D2A0C6392999BD9/");
            listaNoticias.Add("https://s2.glbimg.com/B4KWw3Gl-GZQMQ_-uDIAHGEa8Mg=/0x0:1500x500/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_bc8228b6673f488aa253bbcb03c80ec5/internal_photos/bs/2020/P/t/3teZJcTZeiCyBxRjnHmg/fall-guys.jpg");
        }
    }
}
