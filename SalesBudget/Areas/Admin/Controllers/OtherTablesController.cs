using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBudget.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OtherTablesController : Controller
    {
        //Ritorna la View con i links alle altre viste
        public IActionResult Index()
        {
            return View();
        }
    }
}
