using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class AddCuriosidadeModel : PageModel
    {
        private MySqlDatabase database = MySqlDatabase.getInstance();

        [BindProperty]
        public Curiosidade novaCuriosidade 
        { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //novaCuriosidade = new Curiosidade();
            //novaCuriosidade.titulo = Request.Form["formTitulo"];
            //novaCuriosidade.descricao = Request.Form["formDesc"];
            Console.WriteLine(novaCuriosidade.ToString());
            database.addCuriosidade(novaCuriosidade);
        }
    }
}
