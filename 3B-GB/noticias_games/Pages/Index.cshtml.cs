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
        public List<Noticia> listaNoticias = new List<Noticia>();
        MySqlDatabase database = MySqlDatabase.getInstance();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            listaNoticias = database.getNoticias();
        }
    }
}

// MODEL -> VIEW -> VIEWMODEL
