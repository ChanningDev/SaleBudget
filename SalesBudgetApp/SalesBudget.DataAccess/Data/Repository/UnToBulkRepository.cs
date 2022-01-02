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
    public class UnToBulkRepository : Repository<UnToBulk> , IUnToBulkRepository
    {
        private readonly ApplicationDbContext _db;

        public UnToBulkRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UnToBulk unToBulk)
        {
            var objFromDb = _db.UnToBulk.FirstOrDefault(s => s.UnToBulkId == unToBulk.UnToBulkId);

            objFromDb.ConversionRate = unToBulk.ConversionRate;

            _db.SaveChanges();
        }
    }
}
