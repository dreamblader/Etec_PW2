using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Usuario usuario
        {get; set;}

        [BindProperty]
        public string username
        {get; set;}

        [BindProperty]
        public string password
        {get; set;}

        [BindProperty]
        public string passwordAgain
        {get; set;}

        public bool error;
        private MySqlDatabase database = MySqlDatabase.getInstance();

        public void OnGet()
        {
            error=false;
        }

        public void OnGetError()
        {
            error=true;
        }

        public IActionResult OnPost()
        {
            if(password == passwordAgain)
            {
                database.addUsuario(usuario, username, password);
                return RedirectToPage("Login");
            }
            else
            {
                return RedirectToPage("Register","Error");
            }

            
        }
    }
}
