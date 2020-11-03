using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class LoginModel : PageModel
    {
        
        [BindProperty]
        public string user {get; set;}

        [BindProperty]
        public string pass {get; set;}

        public bool userError;

        private MySqlDatabase database = MySqlDatabase.getInstance();

        public IActionResult OnGet()
        {
            userError = false;

            if(HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToPage("Profile");
            }
            else
            {
                return null;
            }
        }

        public IActionResult OnPost()
        {
            Usuario meuUsuario = database.login(user, pass);

            if(meuUsuario != null)
            {
                Console.WriteLine(meuUsuario.ToString());
                HttpContext.Session.SetInt32("UserId", meuUsuario.id);
                return RedirectToPage("Profile");
            }
            else
            {
                return RedirectToPage("Login", "Error", new {state = true});
            }
        }

        public void OnGetError(bool state)
        {
            userError = state;
        }
    }
}
