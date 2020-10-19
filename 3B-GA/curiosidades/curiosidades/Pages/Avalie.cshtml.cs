using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class AvalieModel : PageModel
    {
        private MySqlDatabase database = MySqlDatabase.getInstance();

        public List<Curiosidade> lista;

        public void OnGet()
        {
            lista = database.getCuriosidades(false);
        }
    }
}
