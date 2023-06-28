using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesBudget.DataAccess.Data.Repository;
using SalesBudget.Models;
using SalesBudget.Models.ViewModels;
using SalesBudget.Utility;
using System;

namespace SalesBudget.Areas.ReadWrite
{
    [Area("Admin")]
    public class BudgetController : Controller
    {
  
        private readonly IUnitOfWork _unitOfWork;

        //Istanzio il ViewModel che utilizzerò in questo controller
        [BindProperty]
        public BudgetViewModel BudgetVM { get; set; }

        //Includo la UnitOfWork per poter comunicare con il db
        public BudgetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //Index Get, metodo di avvio dell'app
        [HttpGet]
        public IActionResult Index()
        {
            BudgetVM = new BudgetViewModel()
            {
                FBudget = new FBudget(),

                //Popolo le tendine nella index tramite il VM
                CompanyList = _unitOfWork.Budget.GetCompanyListForDropDown(),
                YearsList = _unitOfWork.Budget.GetYearsListForDropdown(),
                CustomerList = _unitOfWork.Budget.GetCustomerListForDropDown(),
                ProductGroupList = _unitOfWork.Budget.GetProductGroupListForDropDown(),
                LicensingAreaList = _unitOfWork.Budget.GetLicensingAreaListForDropDown(),
                PharmaFormList = _unitOfWork.Budget.GetPharmaFormListForDropDown(),
                LedgerScenarioList = _unitOfWork.Budget.GetLedgerScenarioListForDropDown(),
                CurrencyList = _unitOfWork.Budget.GetCurrencyListForDropdown(),

            };
            return View(BudgetVM);
        }


        //Filter Post, metodo per il filtraggio dei dati
        [HttpPost]
        public IActionResult Filter(BudgetViewModel budget) //automaticamente va a cercare i parametri nel modello
        {

            //Memorizzo in sessione- (non utilizzato)
            SessionExtension.SetObjectAsJson(HttpContext.Session, "SessionFilter", budget.FBudget);

            //Costruisco la query dinamica in base ai valori ricevuti dai menu a tendina
            BobTheBuilder.Build(budget);

                BudgetVM = new BudgetViewModel()
                {
                    FBudget = new FBudget(),

                    //Popolo le tendine nella index tramite il VM
                    CompanyList = _unitOfWork.Budget.GetCompanyListForDropDown(),
                    YearsList = _unitOfWork.Budget.GetYearsListForDropdown(),
                    CustomerList = _unitOfWork.Budget.GetCustomerListForDropDown(),
                    ProductGroupList = _unitOfWork.Budget.GetProductGroupListForDropDown(),
                    LicensingAreaList = _unitOfWork.Budget.GetLicensingAreaListForDropDown(),
                    PharmaFormList = _unitOfWork.Budget.GetPharmaFormListForDropDown(),
                    LedgerScenarioList = _unitOfWork.Budget.GetLedgerScenarioListForDropDown(),
                    CurrencyList = _unitOfWork.Budget.GetCurrencyListForDropdown(),

                    //Lista di tutti i record filtrati con BobTheBuilder.Build()
                    //Includo le properties dove i campi appartengono ad altre tabelle
                    RecordsList = _unitOfWork.Budget.GetAll(filter: BobTheBuilder.Build(budget), includeProperties: "ItemMaster,Customer")

                };

                return View(BudgetVM);
        }


        //Metodo non utilizzato, serve a mostrare tutti i record esistenti
        public IActionResult ShowAll()
        {
            BudgetVM = new BudgetViewModel()
            {
                FBudget = new FBudget(),

                //Popolo le tendine nella index tramite il VM
                CompanyList = _unitOfWork.Budget.GetCompanyListForDropDown(),
                YearsList = _unitOfWork.Budget.GetYearsListForDropdown(),
                CustomerList = _unitOfWork.Budget.GetCustomerListForDropDown(),
                ProductGroupList = _unitOfWork.Budget.GetProductGroupListForDropDown(),
                LicensingAreaList = _unitOfWork.Budget.GetLicensingAreaListForDropDown(),
                PharmaFormList = _unitOfWork.Budget.GetPharmaFormListForDropDown(),
                LedgerScenarioList = _unitOfWork.Budget.GetLedgerScenarioListForDropDown(),
                CurrencyList = _unitOfWork.Budget.GetCurrencyListForDropdown(),

                //Lista di tutti i record
                //Includo le properties dove i campi appartengono ad altre tabelle
                RecordsList = _unitOfWork.Budget.GetAll(includeProperties: "ItemMaster,Customer")

            };

            return View(BudgetVM);
        }



 

        //MonthlyDetails Get, metodo richiamato alla pressione del bottone MonthlyDetails
        [HttpGet]
        public IActionResult MonthlyDetails(int? id)
        {
            BudgetVM = new BudgetViewModel()
            {
                RecordsList = _unitOfWork.Budget.GetAll(includeProperties: "ItemMaster,Customer")
            };

            if (id != null)
            {
                BudgetVM.FBudget = _unitOfWork.Budget.Get(id.GetValueOrDefault());
            }

            return View(BudgetVM);
        }


        //EditMonthlyDetails Get, metodo che permette di editare il MonthlyDetails
        [HttpGet]
        public IActionResult EditMonthDetail(int? id)
        {

            BudgetVM = new BudgetViewModel();
            {
                FBudget FBudget = new FBudget();
            };

            if (id != null)
            {
                BudgetVM.FBudget = _unitOfWork.Budget.Get(id.GetValueOrDefault());
            }
            else
            {
                return RedirectToAction("RecordNotFound");
            }

            return View(BudgetVM);

        }


        //EditMonthlyDetails Post, metodo per editare e salvare le modicfiche nel db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMonthDetail(BudgetViewModel budget)
        {

            var Total = budget.FBudget.TotalAmount;

            //Il valore totale dei mesi non può essere superiore al TotalAmount
            if (Total >= budget.FBudget.TotalMonths)
            {
                _unitOfWork.Budget.EditMonthDetails(BudgetVM.FBudget);
                _unitOfWork.Save();
                return RedirectToAction("Success");
            }

            return RedirectToAction("FailedTotal");

        }




        //Ritorna la View in caso di operazione riuscita
        public IActionResult Success()
        {
            return View();
        }

        //Ritorna la View in caso di operazione fallita
        public IActionResult FailedTotal()
        {
            return View();
        }

        //Ritorna la View in caso di record non trovato
        public IActionResult RecordNotFound()
        {
            return View();
        }

        //Ritorna la View per BudgetRevision
        public IActionResult BudgetRevision()
        {
            return View();
        }





        //Upsert Get, ritonra la vista di modifica dei record
        [HttpGet]
        public IActionResult Upsert (int? id)
        {
            //Istanzio ViewModel, Model e popolo i menu a tendina
            BudgetVM = new BudgetViewModel()
            {
                FBudget = new FBudget(),

                ItemDescriptionList = _unitOfWork.Budget.GetItemDescriptionListForDropDown(),
                CompanyList = _unitOfWork.Budget.GetCompanyListForDropDown(),
                LedgerScenarioList = _unitOfWork.Budget.GetLedgerScenarioListForDropDown(),
                CustomerList = _unitOfWork.Budget.GetCustomerListForDropDown(),
            };

            if(id != null)
            {
                BudgetVM.FBudget = _unitOfWork.Budget.Get(id.GetValueOrDefault());
            }

            return View(BudgetVM);

        }

        

        //Upsert Post, salva le modifiche nel db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {

                if (BudgetVM.FBudget.BudgetId == 0)//È un create
                {
                    //Nuovo budget
                    _unitOfWork.Budget.Add(BudgetVM.FBudget);
                    
                }
                else//È un update
                {
                    //Modifica budget
                    _unitOfWork.Budget.Update(BudgetVM.FBudget);
                }
                _unitOfWork.Save();


                return RedirectToAction("Success");

            }
            else
            {
                //Ripopolo le tendine nel caso di fallimento dell'operazione di insert
                //altrimenti viene sollevata un eccezione (modelstate = invalid)
                BudgetVM.ItemDescriptionList = _unitOfWork.Budget.GetItemDescriptionListForDropDown();
                BudgetVM.CompanyList = _unitOfWork.Budget.GetCompanyListForDropDown();
                BudgetVM.LedgerScenarioList = _unitOfWork.Budget.GetLedgerScenarioListForDropDown();
                BudgetVM.CustomerList = _unitOfWork.Budget.GetCustomerListForDropDown();

                return View(BudgetVM); //Se il modelstate non è valido
            }
        }



        //Delete
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Budget.Get(id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Budget.Remove(objFromDb);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

    }
}
