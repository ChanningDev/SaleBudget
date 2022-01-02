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
    public class CompanyController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public CompanyViewModel CompanyVM { get; set; }

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            CompanyVM = new CompanyViewModel()
            {
                Company = new Company(),
                RecordsList = _unitOfWork.Company.GetAll()

            };

            return View(CompanyVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            CompanyVM = new CompanyViewModel()
            {
                Company = new Company(),
            };

            if (id != null)
            {
                CompanyVM.Company = _unitOfWork.Company.Get(id.GetValueOrDefault());
            }

            return View(CompanyVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (CompanyVM.Company.CompanyId == 0)
                {
                    _unitOfWork.Company.Add(CompanyVM.Company);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyVM.Company);
                }
                _unitOfWork.Save();


                return RedirectToAction("Success");
            }
            else
            {
                return View(CompanyVM);
            }
        }

        //Non utilizzato al momento
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Company.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Company.Remove(objFromDb);
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
