using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesBudget.DataAccess.Data.Repository;
using SalesBudget.Models;
using SalesBudget.Models.ViewModels;
using SalesBudget.Utility;
using System;

namespace SalesBudget.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UnToKgController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public UnToKgViewModel UnToKgVM { get; set; }

        public UnToKgController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            UnToKgVM = new UnToKgViewModel()
            {
                UnToKg = new UnToKg(),

                RecordsList = _unitOfWork.UnToKg.GetAll()
            };

            return View(UnToKgVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            UnToKgVM = new UnToKgViewModel()
            {
                UnToKg = new UnToKg(),
            };

            if (id != null)
            {
                UnToKgVM.UnToKg= _unitOfWork.UnToKg.Get(id.GetValueOrDefault());
            }

            return View(UnToKgVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {

            if (ModelState.IsValid)
            {
                if (UnToKgVM.UnToKg.UnToKgId == 0)
                {
                    _unitOfWork.UnToKg.Add(UnToKgVM.UnToKg);
                }
                else
                {
                    _unitOfWork.UnToKg.Update(UnToKgVM.UnToKg);
                }
                _unitOfWork.Save();

                return RedirectToAction("Success");
            }
            else
            {
                return View(UnToKgVM);
            }
        }


        //Non utilizzato al momento
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.UnToKg.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.UnToKg.Remove(objFromDb);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }



        public IActionResult Success()
        {
            return View();
        }

        public IActionResult RecordNotFound()
        {
            return View();
        }
    }
}
