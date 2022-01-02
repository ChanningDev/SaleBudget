using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models.ViewModels
{
    public class LedgerTypeViewModel
    {
        public LedgerType LedgerType { get; set; }
        public IEnumerable<LedgerType> RecordsList { get; set; }
    }
}
