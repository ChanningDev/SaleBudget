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
    public class ProductGroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public ProductGroupViewModel ProductGroupVM { get; set; }

        public ProductGroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            ProductGroupVM = new ProductGroupViewModel()
            {
                ProductGroup = new ProductGroup(),

                RecordsList = _unitOfWork.ProductGroup.GetAll()
            };

            return View(ProductGroupVM);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            ProductGroupVM = new ProductGroupViewModel()
            {
                ProductGroup = new ProductGroup(),
            };

            if (id != null)
            {
                ProductGroupVM.ProductGroup = _unitOfWork.ProductGroup.Get(id.GetValueOrDefault());
            }

            return View(ProductGroupVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {

                if (ProductGroupVM.ProductGroup.ProductGroupId == 0)
                {
                    _unitOfWork.ProductGroup.Add(ProductGroupVM.ProductGroup);
                }
                else
                {
                    _unitOfWork.ProductGroup.Update(ProductGroupVM.ProductGroup);
                }
                _unitOfWork.Save();


                return RedirectToAction("Success");
            }
            else
            {
                return View(ProductGroupVM);
            }

        }



        //Non utilizzato al momento
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ProductGroup.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductGroup.Remove(objFromDb);
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
