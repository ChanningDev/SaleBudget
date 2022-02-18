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
    public class PharmaFormController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public PharmaFormViewModel PharmaFormVM { get; set; }

        public PharmaFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            PharmaFormVM = new PharmaFormViewModel()
            {
                PharmaForm = new PharmaForm(),

                RecordsList = _unitOfWork.PharmaForm.GetAll()
            };

            return View(PharmaFormVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            PharmaFormVM = new PharmaFormViewModel()
            {
                PharmaForm = new PharmaForm(),
            };

            if (id != null)
            {
                PharmaFormVM.PharmaForm = _unitOfWork.PharmaForm.Get(id.GetValueOrDefault());
            }

            return View(PharmaFormVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (PharmaFormVM.PharmaForm.PharmaFormId == 0)
                {
                    _unitOfWork.PharmaForm.Add(PharmaFormVM.PharmaForm);
                }
                else
                {
                    _unitOfWork.PharmaForm.Update(PharmaFormVM.PharmaForm);
                }
                _unitOfWork.Save();

                return RedirectToAction("Success");
            }
            else
            {
                return View(PharmaFormVM);
            }
        }



        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.PharmaForm.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.PharmaForm.Remove(objFromDb);
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
