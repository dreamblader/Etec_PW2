using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj01.Pages
{
    public class AdicionarModel : PageModel
    {

        [BindProperty]
        public Noticia novaNoticia
        {get; set;}

        MySqlDatabase database = MySqlDatabase.getInstance();

        public void OnGet()
        {
        }


        public void OnPost()//chamar via Post
        {
            Console.WriteLine(novaNoticia.ToString()); //Object
            database.addNoticia(novaNoticia);
        }
        
    }
}
