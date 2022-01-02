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
    public class UnToBulkController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public UnToBulkViewModel UnToBulkVM { get; set; }

        public UnToBulkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            UnToBulkVM = new UnToBulkViewModel()
            {
                UnToBulk = new UnToBulk(),

                RecordsList = _unitOfWork.UnToBulk.GetAll()

            };

            return View(UnToBulkVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            UnToBulkVM = new UnToBulkViewModel()
            {
                UnToBulk = new UnToBulk(),
            };

            if (id != null)
            {
                UnToBulkVM.UnToBulk = _unitOfWork.UnToBulk.Get(id.GetValueOrDefault());
            }

            return View(UnToBulkVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (UnToBulkVM.UnToBulk.UnToBulkId == 0)
                {
                    _unitOfWork.UnToBulk.Add(UnToBulkVM.UnToBulk);
                }
                else
                {
                    _unitOfWork.UnToBulk.Update(UnToBulkVM.UnToBulk);
                }
                _unitOfWork.Save();

                return RedirectToAction("Success");
            }
            else
            {
                return View(UnToBulkVM);
            }
        }


        //Non utilizzato al momento
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.UnToBulk.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.UnToBulk.Remove(objFromDb);
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
