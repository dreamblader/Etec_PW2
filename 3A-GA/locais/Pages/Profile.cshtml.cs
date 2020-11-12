using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace site.Pages
{
    public class ProfileModel : PageModel
    {
        public Usuario usuario;

        private MySqlDatabase database = MySqlDatabase.getInstance();

        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            usuario = database.getUsuario(id ?? 0);

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
