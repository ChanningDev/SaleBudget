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
    public class ItemMasterRepository : Repository<ItemMaster> ,IItemMasterRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemMasterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        //Un metodo per ogni menu a tendina
        //Ogni metodo serve a popolarli
        //__________________________________________________________________________
        public IEnumerable<SelectListItem> GetPharmaFormListForDropDown()
        {
            return _db.PharmaForm.Select(i => new SelectListItem()
            {
                Text = i.PharmaFormName.ToString(),
                Value = i.PharmaFormId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetProductGroupListForDropDown()
        {
            return _db.ProductGroup.Select(i => new SelectListItem()
            {
                Text = i.ProductGroupName.ToString(),
                Value = i.ProductGroupId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetUnToBulkListForDropDown()
        {
            return _db.UnToBulk.Select(i => new SelectListItem()
            {
                Text = i.ConversionRate.ToString(),
                Value = i.UnToBulkId.ToString()
            }).Distinct();
        }

        public IEnumerable<SelectListItem> GetUnToKgListForDropDown()
        {
            return _db.UnToKg.Select(i => new SelectListItem()
            {
                Text = i.ConversionRate.ToString(),
                Value = i.UnToKgId.ToString()
            }).Distinct();
        }
        //__________________________________________________________________________


        //Update, aggiorna i dati del record nel db (create e edit)
        //Non tutti i campi sono presenti, in quanto alcuni vengono autocalcolatri direttamente all'interno del model
        public void Update(ItemMaster itemMaster)
        {
            var objFromDb = _db.ItemMaster.FirstOrDefault(s => s.ItemMasterId == itemMaster.ItemMasterId);

            objFromDb.ItemNumber = itemMaster.ItemNumber;
            objFromDb.ShortItem = itemMaster.ShortItem;
            objFromDb.ItemDescription = itemMaster.ItemDescription;
            objFromDb.UnitOfMeasure = itemMaster.UnitOfMeasure;
            objFromDb.PharmaFormId = itemMaster.PharmaFormId;
            objFromDb.ProductGroupId = itemMaster.ProductGroupId;
            objFromDb.UnToBulkId = itemMaster.UnToBulkId;
            objFromDb.UnToKgId = itemMaster.UnToKgId;


            _db.SaveChanges();
        }
    }
}
