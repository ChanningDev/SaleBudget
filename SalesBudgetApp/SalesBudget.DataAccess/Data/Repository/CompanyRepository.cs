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
    public class CompanyRepository : Repository<Company> ,ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var objFromDb = _db.Company.FirstOrDefault(s => s.CompanyId == company.CompanyId);

            objFromDb.CompanyName = company.CompanyName;
            objFromDb.Acronym = company.Acronym;
            objFromDb.CurrencyBase = company.CurrencyBase;
            objFromDb.CurrenyGroup = company.CurrenyGroup;
            objFromDb.Operative = company.Operative;


            _db.SaveChanges();

        }
    }
}
