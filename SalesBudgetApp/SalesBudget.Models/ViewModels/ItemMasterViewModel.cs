using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models.ViewModels
{
    public class ItemMasterViewModel
    {
        //Lista della classe modello ItemMaster
        public ItemMaster ItemMaster { get; set; }

        //Liste contenenti i valori estratti dai metodi nel repository
        public IEnumerable<ItemMaster> RecordsList { get; set; }
        public IEnumerable<SelectListItem> PharmaFormList { get; set; }
        public IEnumerable<SelectListItem> ProductGroupList { get; set; }
        public IEnumerable<SelectListItem> UnToBulkList { get; set; }
        public IEnumerable<SelectListItem> UnToKgList { get; set; }
    }
}
