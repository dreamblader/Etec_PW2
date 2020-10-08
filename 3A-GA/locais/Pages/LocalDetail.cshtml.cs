using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace site.Pages
{
    public class LocalDetailModel : PageModel
    {

        [BindProperty(SupportsGet=true)]
        public int id{get; set;}

        MySqlDatabase database = MySqlDatabase.getInstance();

        public Local meuLocal;

        public void OnGet()
        {
            meuLocal = database.getLocal(id);
            //Console.WriteLine(meuLocal.ToString());
        }
    }
}
