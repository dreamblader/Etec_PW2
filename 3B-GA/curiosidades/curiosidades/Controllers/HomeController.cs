using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace proj01.Controllers
{
    public class HomeController : Controller
    {
        private MySqlDatabase database;


        public HomeController()
        {
            database = new MySqlDatabase();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
