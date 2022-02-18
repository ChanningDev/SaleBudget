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
    public class ProductGroupRepository : Repository<ProductGroup> ,IProductGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductGroupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductGroup productGroup)
        {
            var objFromDb = _db.ProductGroup.FirstOrDefault(s => s.ProductGroupId == productGroup.ProductGroupId);

            objFromDb.ProductGroupCode = productGroup.ProductGroupCode;
            objFromDb.ProductGroupAcronym = productGroup.ProductGroupAcronym;
            objFromDb.ProductGroupName = productGroup.ProductGroupName;

            _db.SaveChanges();
        }
    }
}
