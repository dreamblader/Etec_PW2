using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace site.Pages
{
    public class LoginModel : PageModel
    {

        private MySqlDatabase database = MySqlDatabase.getInstance();

        [BindProperty]
        public string username
        { get; set; }

        [BindProperty]
        public string password
        { get; set; }

        public Boolean erro;

        public void OnGet()
        {
            erro=false;
        }

        public void OnGetErro()
        {
            erro=true;
        }

        public IActionResult OnPost()
        {
            Usuario meuUsuario = database.login(username, password);

            if(meuUsuario != null)
            {
                Console.WriteLine(meuUsuario.ToString());
                return RedirectToPage("Profile");
            }
            else
            {
                return RedirectToPage("Login", "Erro");
            }
        }
    }
}
