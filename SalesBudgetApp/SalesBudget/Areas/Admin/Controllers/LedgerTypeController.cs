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
    public class LedgerTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public LedgerTypeViewModel LedgerTypeVM { get; set; }

        public LedgerTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            LedgerTypeVM = new LedgerTypeViewModel()
            {
                LedgerType = new LedgerType(),

                RecordsList = _unitOfWork.LedgerType.GetAll()
            };

            return View(LedgerTypeVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            LedgerTypeVM = new LedgerTypeViewModel()
            {
                LedgerType = new LedgerType(),
            };

            if (id != null)
            {
                LedgerTypeVM.LedgerType = _unitOfWork.LedgerType.Get(id.GetValueOrDefault());
            }

            return View(LedgerTypeVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {

                if (LedgerTypeVM.LedgerType.LedgerTypeId == 0)
                {
                    _unitOfWork.LedgerType.Add(LedgerTypeVM.LedgerType);
                }
                else
                {
                    _unitOfWork.LedgerType.Update(LedgerTypeVM.LedgerType);
                }
                _unitOfWork.Save();


                return RedirectToAction("Success");
            }
            else
            {
                return View(LedgerTypeVM);
            }
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.LedgerType.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.LedgerType.Remove(objFromDb);
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
