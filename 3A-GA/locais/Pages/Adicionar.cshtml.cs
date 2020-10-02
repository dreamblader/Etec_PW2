using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace site.Pages
{
    public class AdicionarModel : PageModel
    {

        private MySqlDatabase database = MySqlDatabase.getInstance();

        [BindProperty]
        public Local localForm
        { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine(localForm.ToString());
            database.addLocal(localForm);
        }
    }
}
