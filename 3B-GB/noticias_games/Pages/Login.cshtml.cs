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
        public string username {get; set;}

        [BindProperty]
        public string password {get; set;}

        private MySqlDatabase database = MySqlDatabase.getInstance();

        public bool erro;

        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("id_user");
            erro= false;

            if(id!=null)
            {
                return RedirectToPage("Profile");
            }
            else
            {
                return null;
            }
            
        }

        public void OnGetError()
        {
            erro= true;
        }

        public IActionResult OnPost()
        {
            Usuario meuUsuario = database.login(username, password);

            if(meuUsuario != null)
            {
                //Console.WriteLine(meuUsuario.ToString());
                HttpContext.Session.SetInt32("id_user", meuUsuario.id);
                return RedirectToPage("Profile");
            }
            else
            {
                return RedirectToPage("Login", "Error");
            }
        }
    }
}
