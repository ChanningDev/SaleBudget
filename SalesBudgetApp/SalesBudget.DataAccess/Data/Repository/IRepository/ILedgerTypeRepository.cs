using Microsoft.AspNetCore.Mvc.Rendering;
using SalesBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.DataAccess.Data.Repository.IRepository
{
    /*IMPLEMENTA I METODI DEL REPOSITORY*/
    public interface ILedgerTypeRepository : IRepository<LedgerType>
    {
        void Update(LedgerType ledgerType);
    }
}
