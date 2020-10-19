using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class NoticiasModel : PageModel
    {
        MySqlDatabase database = MySqlDatabase.getInstance();

        public List<Noticia> lista;

        public void OnGet()
        {
            lista = database.getNoticias();
        }
    }
}
