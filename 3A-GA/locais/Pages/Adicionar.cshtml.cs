using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult OnGet()
        {
            return checkSession();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine(localForm.ToString());

            IActionResult result = checkSession();

            if(result != null)
            {
                return result;
            }

            database.addLocal(localForm);

            return null;
        }

        private IActionResult checkSession()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            Usuario usuario = database.getUsuario(id ?? 0);

            if(usuario == null)
            {
                HttpContext.Session.Remove("userId");
                return RedirectToPage("Login");
            }
            else
            {
                return null;
            }
        }
    }
}
