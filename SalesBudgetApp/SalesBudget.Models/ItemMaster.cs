using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    //Rappresenta l'omonima tabella nel db
    public class ItemMaster
    {

        [Key]
        public int ItemMasterId { get; set; }

        [Required(ErrorMessage = "ItemNumber is required.")]
        public int ItemNumber { get; set; }

        [Required(ErrorMessage = "ShortItem is required.")]
        public string ShortItem { get; set; }

        [Required(ErrorMessage = "ItemDescription is required.")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "UnitOfMeasure is required.")]
        public string UnitOfMeasure { get; set; }


        //Accesso ala tabella padre
        public ICollection<FBudget> FBudgets { get; set; }


        //Chiavi esterne
        //Accesso a PharmaForm
        public int PharmaFormId { get; set; }
        public PharmaForm PharmaForm { get; set; }


        //Accesso a ProductGroup
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }


        //Accesso a UnToBulk
        public int UnToBulkId { get; set; }
        public UnToBulk UnToBulk { get; set; }


        //Accesso a UnToKg
        public int UnToKgId { get; set; }
        public UnToKg UnToKg { get; set; }

    }
}
