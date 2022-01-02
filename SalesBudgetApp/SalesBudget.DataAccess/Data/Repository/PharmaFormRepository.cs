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
    public class PharmaFormRepository : Repository<PharmaForm> ,IPharmaFormRepository
    {
        private readonly ApplicationDbContext _db;

        public PharmaFormRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PharmaForm pharmaForm)
        {
            var objFromDb = _db.PharmaForm.FirstOrDefault(s => s.PharmaFormId == pharmaForm.PharmaFormId);

            objFromDb.PharmaFormAcronym = pharmaForm.PharmaFormAcronym;
            objFromDb.PharmaFormName = pharmaForm.PharmaFormName;


            _db.SaveChanges();
        }
    }
}
