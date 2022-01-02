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
    public class LedgerTypeRepository : Repository<LedgerType> ,ILedgerTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LedgerTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(LedgerType ledgerType)
        {
            var objFromDb = _db.LedgerType.FirstOrDefault(s => s.LedgerTypeId == ledgerType.LedgerTypeId);

            objFromDb.LedgerTypeCode = ledgerType.LedgerTypeCode;
            objFromDb.Scenario = ledgerType.Scenario;
            objFromDb.Statutory = ledgerType.Statutory;

            _db.SaveChanges();
        }
    }
}
