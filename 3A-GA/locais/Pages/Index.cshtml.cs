using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace site.Pages
{
    public class IndexModel : PageModel
    {
        public string nomeWeb = "LocaisWeb";
        private MySqlDatabase database = MySqlDatabase.getInstance(); //SINGLETON
        public Local localSelecionado;
        public int antId;
        public int proxId;
        
        public List<Local> locais = new List<Local>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet =true)]
        public int id { get; set; }

        public void OnGet()
        {
            locais = database.getLocalHome();

            localSelecionado = locais[id];

            proxId = id+1;
            if (proxId >= locais.Count)
            {
                proxId = 0;
            }

            antId = id-1;
            if (antId < 0)
            {
                antId = locais.Count-1;
            }
        }

    }
}
