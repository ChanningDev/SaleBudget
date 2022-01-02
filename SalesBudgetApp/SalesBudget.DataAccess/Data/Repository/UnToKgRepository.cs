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
    public class UnToKgRepository : Repository<UnToKg> , IUnToKgRepository
    {
        private readonly ApplicationDbContext _db;

        public UnToKgRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UnToKg unToKg)
        {
            var objFromDb = _db.UnToKg.FirstOrDefault(s => s.UnToKgId == unToKg.UnToKgId);

            objFromDb.ConversionRate = unToKg.ConversionRate;

            _db.SaveChanges();

        }
    }
}
