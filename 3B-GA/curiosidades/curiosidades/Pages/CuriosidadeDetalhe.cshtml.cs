using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class CuriosidadeDetalheModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int id {get; set;}

        public Curiosidade minhaCuriosidade;

        MySqlDatabase database = MySqlDatabase.getInstance();

        public void OnGet()
        {
            
            minhaCuriosidade = database.getCuriosidade(id);
            Console.WriteLine(minhaCuriosidade.ToString());
        }
    }
}
