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
        private MySqlDatabase database = MySqlDatabase.getInstance();
        public string nome = "Nome do App Aqui";

        public List<Curiosidade> bestCuriosidades
        {get; set;}

        public List<string> avalieCuriosidades = new List<string>();
        public List<Usuario> usuarios = new List<Usuario>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            bestCuriosidades = database.getCuriosidades();
            usuarios = database.getUsuarios();

            avalieCuriosidades.Add("Curiosidade Sobre Leões");
            avalieCuriosidades.Add("Curiosidade Sobre o Mar");
            avalieCuriosidades.Add("Curiosidade Sobre Playdoh");
     
        }
    }
}
