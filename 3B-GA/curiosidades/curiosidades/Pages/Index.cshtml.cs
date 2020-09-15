using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace proj01.Pages
{
    public class IndexModel : PageModel
    {
        public string nome = "Nome do App Aqui";

        public List<string> bestCuriosidades = new List<string>();
        public List<string> avalieCuriosidades = new List<string>();
        public List<string> usuarios = new List<string>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            bestCuriosidades.Add("Top 1 - Curiosidade");
            bestCuriosidades.Add("Top 2 - Curiosidade");
            bestCuriosidades.Add("Top 3 - Curiosidade");
            bestCuriosidades.Add("Top 4 - Curiosidade");
            bestCuriosidades.Add("Top 5 - Curiosidade");

            avalieCuriosidades.Add("Curiosidade Sobre Leões");
            avalieCuriosidades.Add("Curiosidade Sobre o Mar");
            avalieCuriosidades.Add("Curiosidade Sobre Playdoh");

            usuarios.Add("1");
        }
    }
}
