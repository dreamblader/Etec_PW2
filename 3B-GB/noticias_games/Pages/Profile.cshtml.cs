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
        public Usuario perfil;

        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("id_user");
            perfil = database.getUsuario(id ?? 0);

            if(perfil == null)
            {
                HttpContext.Session.Remove("id_user");
                return RedirectToPage("Login");
            }
            else
            {
                return null;
            }
        }
    }
}
