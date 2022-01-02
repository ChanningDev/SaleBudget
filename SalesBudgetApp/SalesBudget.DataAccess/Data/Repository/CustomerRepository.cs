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
    public class CustomerRepository : Repository<Customer> ,ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer customer)
        {
            var objFromDb = _db.Customer.FirstOrDefault(s => s.CustomerId == customer.CustomerId);

            objFromDb.CustomerGroupName = customer.CustomerName;
            objFromDb.CustomerGroupCode = customer.CustomerGroupCode;
            objFromDb.CountryCode = customer.CountryCode;
            objFromDb.CustomerGroupName = customer.CustomerGroupName;
            objFromDb.LicensingArea = customer.LicensingArea;


            _db.SaveChanges();

        }
    }
}
