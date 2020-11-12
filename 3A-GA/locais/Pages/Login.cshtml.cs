using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult OnGet()
        {
            erro=false;

            if(HttpContext.Session.GetInt32("userId") != null)
            {
                return RedirectToPage("Profile");
            }
            else
            {
                return null;
            }
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
                HttpContext.Session.SetInt32("userId", meuUsuario.id);

                //Console.WriteLine(meuUsuario.ToString());
                return RedirectToPage("Profile");
            }
            else
            {
                return RedirectToPage("Login", "Erro");
            }
        }
    }
}

