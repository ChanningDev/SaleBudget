using Microsoft.AspNetCore.Mvc.Rendering;
using SalesBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.DataAccess.Data.Repository.IRepository
{
    //Implementa i metodi del repository
    public interface IBudgetRepository : IRepository<FBudget>
    {
        IEnumerable<SelectListItem> GetItemNumberListForDropDown();
        IEnumerable<SelectListItem> GetItemDescriptionListForDropDown();
        IEnumerable<SelectListItem> GetPharmaFormListForDropDown();
        IEnumerable<SelectListItem> GetProductGroupListForDropDown();
        IEnumerable<SelectListItem> GetCompanyListForDropDown();
        IEnumerable<SelectListItem> GetLedgerTypeListForDropDown();
        IEnumerable<SelectListItem> GetLedgerScenarioListForDropDown();
        IEnumerable<SelectListItem> GetCustomerListForDropDown();
        IEnumerable<SelectListItem> GetLicensingAreaListForDropDown();
        IEnumerable<SelectListItem> GetYearsListForDropdown();
        IEnumerable<SelectListItem> GetCurrencyListForDropdown();
        void Update(FBudget budget);
        void EditMonthDetails(FBudget budget);
        IQueryable<float> GetTotalAmount();
    }
}


