using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class ProfileModel : PageModel
    {
        private MySqlDatabase database = MySqlDatabase.getInstance();

        public Usuario meuUsuario;

        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("UserId");

            if(id != null)
            {
                //GET NO DATABASE DO PERFIL
                meuUsuario = database.getUsuario(id ?? 0);
                Console.WriteLine(meuUsuario.ToString());
                return null;
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}
