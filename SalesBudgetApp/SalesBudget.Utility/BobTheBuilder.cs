using SalesBudget.Models;
using SalesBudget.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Utility
{
    //Classe per la costruzione di una query dinamica in base ai parametri ricevuti
    public static class BobTheBuilder
    {
        public static Expression<Func<FBudget, bool>> Build(BudgetViewModel budget)
        {
            var b = Expression.Parameter(typeof(FBudget), "b");
            var filterParts = new List<Expression>();

            if (budget.FBudget.Year is { } year && year != 0)
            {
                var budgetYear = Expression.Property(b, nameof(FBudget.Year));
                var testYear = Expression.Constant(year);
                filterParts.Add(Expression.Equal(budgetYear, testYear));
            }

            if (budget.FBudget.CompanyId is { } companyId && companyId != 0)
            {
                var budgetCompanyId = Expression.Property(b, nameof(FBudget.CompanyId));
                var testCompanyId = Expression.Constant(companyId);
                filterParts.Add(Expression.Equal(budgetCompanyId, testCompanyId));
            }

            if (budget.FBudget.CustomerId is { } customerId && customerId != 0)
            {
                var budgetCustomerId = Expression.Property(b, nameof(FBudget.CustomerId));
                var testCustomerId = Expression.Constant(customerId);
                filterParts.Add(Expression.Equal(budgetCustomerId, testCustomerId));
            }

            if (budget.FBudget.Customer.LicensingArea is { } licensingArea && licensingArea != null)
            {
                var budgetCustomer = Expression.Property(b, nameof(FBudget.Customer));
                var budgetLicensingArea = Expression.Property(budgetCustomer, nameof(Customer.LicensingArea));
                var testLicensingArea = Expression.Constant(licensingArea);
                filterParts.Add(Expression.Equal(budgetLicensingArea, testLicensingArea));
            }


            if (budget.FBudget.ItemMaster.ProductGroupId is { } productGroupId && productGroupId != 0)
            {
                var budgetItemMaster = Expression.Property(b, nameof(FBudget.ItemMaster));
                var budgetProductGroupId = Expression.Property(budgetItemMaster, nameof(ItemMaster.ProductGroupId));
                var testProductGroupId = Expression.Constant(productGroupId);
                filterParts.Add(Expression.Equal(budgetProductGroupId, testProductGroupId));
            }

            if (budget.FBudget.ItemMaster.PharmaFormId is { } pharmaFormId && pharmaFormId != 0)
            {
                var budgetItemMaster = Expression.Property(b, nameof(FBudget.ItemMaster));
                var budgetPharmaFormId = Expression.Property(budgetItemMaster, nameof(ItemMaster.PharmaFormId));
                var testPharmaFormId = Expression.Constant(pharmaFormId);
                filterParts.Add(Expression.Equal(budgetPharmaFormId, testPharmaFormId));
            }

            if (budget.FBudget.Currency is { } currency && currency != null)
            {
                var budgetCurrency = Expression.Property(b, nameof(FBudget.Currency));
                var testCurrency = Expression.Constant(currency);
                filterParts.Add(Expression.Equal(budgetCurrency, testCurrency));
            }

            if (budget.FBudget.LedgerTypeId is { } ledgerTypeId && ledgerTypeId != 0)
            {
                var budgetLedgerTypeId = Expression.Property(b, nameof(FBudget.LedgerTypeId));
                var testLedgerTypeId = Expression.Constant(ledgerTypeId);
                filterParts.Add(Expression.Equal(budgetLedgerTypeId, testLedgerTypeId));
            }



            if (filterParts.Count == 0) return null;

            var body = filterParts.Aggregate(Expression.AndAlso);


            return Expression.Lambda<Func<FBudget, bool>>(body, b);

        }

    }
}
