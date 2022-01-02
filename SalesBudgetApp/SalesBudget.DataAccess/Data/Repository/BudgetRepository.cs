using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesBudget.DataAccess.Data.Repository.IRepository;
using SalesBudget.Models;
using SalesBudget.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SalesBudget.Utility;

namespace SalesBudget.DataAccess.Data.Repository
{
    public class BudgetRepository : Repository<FBudget> ,IBudgetRepository
    {
        private readonly ApplicationDbContext _db;

        public BudgetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


     
        //Un metodo per ogni menu a tendina
        //Ogni metodo serve a popolarli
        //__________________________________________________________________________
        public IEnumerable<SelectListItem> GetItemNumberListForDropDown()
        {
            return _db.ItemMaster.Select(i => new SelectListItem()
            {
                Text = i.ItemNumber.ToString(),
                Value = i.ItemMasterId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetItemDescriptionListForDropDown()
        {
            return _db.ItemMaster.Select(i => new SelectListItem()
            {
                Text = i.ItemDescription.ToString(),
                Value = i.ItemMasterId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetPharmaFormListForDropDown()
        {
            return _db.PharmaForm.Select(i => new SelectListItem()
            {
                Text = i.PharmaFormName.ToString(),
                Value = i.PharmaFormId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetProductGroupListForDropDown()
        {
            return _db.ProductGroup.Select(i => new SelectListItem()
            {
                Text = i.ProductGroupName.ToString(),
                Value = i.ProductGroupId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetCompanyListForDropDown()
        {
            return _db.Company.Select(i => new SelectListItem()
            {
                Text = i.Acronym.ToString(),
                Value = i.CompanyId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetLedgerTypeListForDropDown()
        {
            return _db.LedgerType.Select(i => new SelectListItem()
            {
                Text = i.LedgerTypeCode.ToString(),
                Value = i.LedgerTypeId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetLedgerScenarioListForDropDown()
        {
            return _db.LedgerType.Select(i => new SelectListItem()
            {
                Text = i.Scenario.ToString(),
                Value = i.LedgerTypeId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetCustomerListForDropDown()
        {
            return _db.Customer.Select(i => new SelectListItem()
            {
                Text = i.CustomerName.ToString(),
                Value = i.CustomerId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetLicensingAreaListForDropDown()
        {
            return _db.Customer.Select(i => new SelectListItem()
            {
                Text = i.LicensingArea.ToString(),
                Value = i.LicensingArea
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetYearsListForDropdown()
        {
            return _db.Budget.Select(i => new SelectListItem()
            {
                Text = i.Year.ToString(),
                Value = i.Year.ToString()
            }).Distinct();
        }
        public IEnumerable<SelectListItem> GetCurrencyListForDropdown()
        {
            return _db.Budget.Select(i => new SelectListItem()
            {
                Text = i.Currency.ToString(),
                Value = i.Currency.ToString()
            }).Distinct();
        }

        public IQueryable<float> GetTotalAmount()
        {
            return _db.Budget.Select(i => i.TotalAmount);
        }
        //__________________________________________________________________________



        //Update, aggiorna i dati del record nel db (create e edit)
        //Non tutti i campi sono presenti, in quanto alcuni vengono autocalcolatri direttamente all'interno del model
        public void Update(FBudget budget)
        {
            //recupero id
            var objFromDb = _db.Budget.FirstOrDefault(s => s.BudgetId == budget.BudgetId);

            objFromDb.Year = budget.Year;
            objFromDb.FreeOfCharge = budget.FreeOfCharge;
            objFromDb.Currency = budget.Currency;
            objFromDb.UnitPrice = budget.UnitPrice;
            objFromDb.MonthNr = budget.MonthNr;
            objFromDb.UnitOfMeasure = budget.UnitOfMeasure;
            objFromDb.Quantity = budget.Quantity;
            objFromDb.LastUser = budget.LastUser; //parametro da assegnare direttamente nel model
            objFromDb.ProgramId = budget.ProgramId; //parametro da assegnare direttamente nel model
            objFromDb.ItemMasterId = budget.ItemMasterId;
            objFromDb.CompanyId = budget.CompanyId;
            objFromDb.LedgerTypeId = budget.LedgerTypeId;
            objFromDb.CustomerId = budget.CustomerId;
            
            _db.SaveChanges();

        }


        //EditMonthDetails, salva le modifiche nel db quando si suddivide il budget in mensilità
        public void EditMonthDetails(FBudget budget)
        {
            var objFromDb = _db.Budget.FirstOrDefault(s => s.BudgetId == budget.BudgetId);

            objFromDb.Jan = budget.Jan;
            objFromDb.Feb = budget.Feb;
            objFromDb.Mar = budget.Mar;
            objFromDb.Apr = budget.Apr;
            objFromDb.May = budget.May;
            objFromDb.Jun = budget.Jun;
            objFromDb.Jul = budget.Jul;
            objFromDb.Ago = budget.Ago;
            objFromDb.Sept = budget.Sept;
            objFromDb.Oct = budget.Oct;
            objFromDb.Nov = budget.Nov;
            objFromDb.Dec = budget.Dec;

            objFromDb.TotalAmount = budget.TotalAmount;
            objFromDb.TotalMonths = budget.TotalMonths;

            _db.SaveChanges();
        }   
    }
}
