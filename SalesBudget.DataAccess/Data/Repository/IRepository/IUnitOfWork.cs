using SalesBudget.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.DataAccess.Data.Repository
{
    //Rappresenta tutto ciò che fa l'utente in una singola transazione
    //Ha accesso a tutti i repository e ai metodi di salvataggio per inviare le modifiche al db
    public interface IUnitOfWork : IDisposable
    {
        IBudgetRepository Budget { get; set; }
        ICompanyRepository Company { get; set; }
        ICustomerRepository Customer { get; set; }
        IItemMasterRepository ItemMaster { get; set; }
        ILedgerTypeRepository LedgerType { get; set; }
        IPharmaFormRepository PharmaForm { get; set; }
        IProductGroupRepository ProductGroup { get; set; }
        IUnToBulkRepository UnToBulk { get; set; }
        IUnToKgRepository UnToKg { get; set; }
        
        void Save();
    }
}



