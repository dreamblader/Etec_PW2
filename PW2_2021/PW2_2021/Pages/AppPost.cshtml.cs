using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class AppPostModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public String name { get; set; }

        [BindProperty]
        public String appName {get; set;}

        [BindProperty]
        public String appDesc {get; set;}

        [BindProperty]
        public String appPrice {get; set;}

        [BindProperty]
        public String appFile {get; set;}

        [BindProperty]
        public Boolean terms {get; set;}

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

    }
}
