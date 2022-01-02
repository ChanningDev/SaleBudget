using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBudget.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CopyFromToController : Controller
    {
        
        //Ritorno la View, al momento vuota in quanto a funzionalità deve ancora essere implementata
        public IActionResult Index()
        {
            return View();
        }
    }
}
