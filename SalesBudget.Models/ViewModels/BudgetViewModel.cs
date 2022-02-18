using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models.ViewModels
{
    public class BudgetViewModel
    {
        //Lista della classe modello FBudget
        public FBudget FBudget { get; set; }

        //Liste contenenti i valori estratti dai metodi nel repository
        public IEnumerable<FBudget> RecordsList { get; set; }
        public IEnumerable<SelectListItem> ItemNumberList { get; set; }
        public IEnumerable<SelectListItem> ItemDescriptionList { get; set; }
        public IEnumerable<SelectListItem> PharmaFormList { get; set; }
        public IEnumerable<SelectListItem> ProductGroupList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<SelectListItem> LedgerTypeList { get; set; }
        public IEnumerable<SelectListItem> LedgerScenarioList { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> LicensingAreaList { get; set; }
        public IEnumerable<SelectListItem> YearsList { get; set; }
        public IEnumerable<SelectListItem> CurrencyList { get; set; }
    }
}
