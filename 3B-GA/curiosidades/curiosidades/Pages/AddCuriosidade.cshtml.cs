using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class AddCuriosidadeModel : PageModel
    {
        private MySqlDatabase database = MySqlDatabase.getInstance();

        private int id;

        [BindProperty]
        public Curiosidade novaCuriosidade 
        { get; set; }

        public IActionResult OnGet()
        {
            return checkSession();
        }

        public IActionResult OnPost()
        {
            //novaCuriosidade = new Curiosidade();
            //novaCuriosidade.titulo = Request.Form["formTitulo"];
            //novaCuriosidade.descricao = Request.Form["formDesc"];
            IActionResult redirect = checkSession();

            if(redirect != null)
            {
                return redirect;
            }

            Console.WriteLine(novaCuriosidade.ToString());
            novaCuriosidade.usuarioId = id;
            database.addCuriosidade(novaCuriosidade);

            return RedirectToPage("Index");
        }

        private IActionResult checkSession()
        {
            id = HttpContext.Session.GetInt32("UserId") ?? 0;
            Usuario meuUsuario = database.getUsuario(id);       
         
            if(meuUsuario == null)
            {
                HttpContext.Session.Remove("UserId");
                return RedirectToPage("Login", "AddRedirect");
            }
            else
            {
                return null;
            }
        }
    }
}
