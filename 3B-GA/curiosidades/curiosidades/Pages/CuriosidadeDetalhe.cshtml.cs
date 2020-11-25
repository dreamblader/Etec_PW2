using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class CuriosidadeDetalheModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int id {get; set;}

        [BindProperty]
        public int nota {get; set;}

        public Curiosidade minhaCuriosidade;

        MySqlDatabase database = MySqlDatabase.getInstance();

        public bool userIsConnected;

        public void OnGet()
        {
            
            minhaCuriosidade = database.getCuriosidade(id);

            if(minhaCuriosidade == null)
            {
                minhaCuriosidade = new Curiosidade();
            }
            else if(!minhaCuriosidade.reviewed)
            {
                int? userId =  HttpContext.Session.GetInt32("UserId");
                userIsConnected = userId != null;

                nota = database.getReview(userId ?? 0, id);
                
            }
            
            
        }

        public IActionResult OnPost()
        {
            int userId =  HttpContext.Session.GetInt32("UserId") ?? 0;

            bool notaExiste = database.getReview(userId, id) > 0;

            if(notaExiste)
            {
                database.updateReview(userId, id, nota);
            }
            else
            {
                database.addReview(userId, id, nota);
                database.addScore(userId, 2);
            }
            
            return RedirectToPage("CuriosidadeDetalhe", new{ id = id});
        }
    }
}
