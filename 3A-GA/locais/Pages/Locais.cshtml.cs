using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace site.Pages
{
    public class LocaisModel : PageModel
    {
        MySqlDatabase database = MySqlDatabase.getInstance();
        public List<Local> list = new List<Local>();

        public void OnGet()
        {
            list = database.getLocais(true);
        }
    }
}
