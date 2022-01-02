using SalesBudget.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        //Ho un oggetto istanziato per ogni classe modello
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Budget = new BudgetRepository(_db);
            Company = new CompanyRepository(_db);
            Customer = new CustomerRepository(_db);
            ItemMaster = new ItemMasterRepository(_db);
            LedgerType = new LedgerTypeRepository(_db);
            PharmaForm = new PharmaFormRepository(_db);
            ProductGroup = new ProductGroupRepository(_db);
            UnToBulk = new UnToBulkRepository(_db);
            UnToKg = new UnToKgRepository(_db);
            
        }

        //La UnitOfWork deve essere a conoscenza delle repository esistenti per poter lavorare con il db
        public IBudgetRepository Budget { get; set; }
        public ICompanyRepository Company { get; set; }
        public ICustomerRepository Customer { get; set; }
        public IItemMasterRepository ItemMaster { get; set; }
        public ILedgerTypeRepository LedgerType { get; set; }
        public IPharmaFormRepository PharmaForm { get; set; }
        public IProductGroupRepository ProductGroup { get; set; }
        public IUnToBulkRepository UnToBulk { get; set; }
        public IUnToKgRepository UnToKg { get; set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

