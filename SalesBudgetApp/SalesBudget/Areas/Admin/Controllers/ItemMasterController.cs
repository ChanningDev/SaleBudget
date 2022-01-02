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
    public class ItemMasterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public ItemMasterViewModel ItemMasterVM { get; set; }

        public ItemMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            ItemMasterVM = new ItemMasterViewModel()
            {
                ItemMaster = new ItemMaster(),

                //Lista di tutti i record
                //Includo e properties per includere i campi dele tabelle esterne
                RecordsList = _unitOfWork.ItemMaster.GetAll(includeProperties: "PharmaForm,ProductGroup,UnToBulk,UnToKg")

            };

            return View(ItemMasterVM);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            ItemMasterVM = new ItemMasterViewModel()
            {
                ItemMaster = new ItemMaster(),

                ProductGroupList = _unitOfWork.ItemMaster.GetProductGroupListForDropDown(),
                PharmaFormList = _unitOfWork.ItemMaster.GetPharmaFormListForDropDown(),
                UnToBulkList = _unitOfWork.ItemMaster.GetUnToBulkListForDropDown(),
                UnToKgList = _unitOfWork.ItemMaster.GetUnToKgListForDropDown(),
            };

            if (id != null)
            {
                ItemMasterVM.ItemMaster = _unitOfWork.ItemMaster.Get(id.GetValueOrDefault());
            }

            return View(ItemMasterVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (ItemMasterVM.ItemMaster.ItemMasterId == 0)
                {
                    _unitOfWork.ItemMaster.Add(ItemMasterVM.ItemMaster);
                }
                else
                {
                    _unitOfWork.ItemMaster.Update(ItemMasterVM.ItemMaster);
                }
                _unitOfWork.Save();


                return RedirectToAction("Success");
            }
            else
            {
                ItemMasterVM.ProductGroupList = _unitOfWork.ItemMaster.GetProductGroupListForDropDown();
                ItemMasterVM.PharmaFormList = _unitOfWork.ItemMaster.GetPharmaFormListForDropDown();
                ItemMasterVM.UnToBulkList = _unitOfWork.ItemMaster.GetUnToBulkListForDropDown();
                ItemMasterVM.UnToKgList = _unitOfWork.ItemMaster.GetUnToKgListForDropDown();

                return View(ItemMasterVM);
            }
        }



        //Non utilizzato al momento
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ItemMaster.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.ItemMaster.Remove(objFromDb);
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
