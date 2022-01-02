using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SalesBudget.DataAccess.Data.Repository;
using SalesBudget.Models;
using SalesBudget.Models.ViewModels;
using SalesBudget.Utility;
using System;


namespace SalesBudget.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public CustomerViewModel CustomerVM { get; set; }

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            CustomerVM = new CustomerViewModel()
            {
                Customer = new Customer(),
                RecordsList = _unitOfWork.Customer.GetAll()
            };

            return View(CustomerVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            CustomerVM = new CustomerViewModel()
            {
                Customer = new Customer(),
            };

            if (id != null)
            {
                CustomerVM.Customer = _unitOfWork.Customer.Get(id.GetValueOrDefault());
            }

            return View(CustomerVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Upsert()
        {
            
            if (ModelState.IsValid)
            {

                if (CustomerVM.Customer.CustomerId == 0)
                {
                    _unitOfWork.Customer.Add(CustomerVM.Customer);
                }
                else
                {
                    _unitOfWork.Customer.Update(CustomerVM.Customer);
                }
                _unitOfWork.Save();

                return RedirectToAction("Success");
            }
            else
            {
                return View(CustomerVM);
            }
        }


        //Non utilizzato al momento
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Customer.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Customer.Remove(objFromDb);
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
