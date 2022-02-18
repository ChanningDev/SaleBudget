using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    public class ProductGroup
    {
        [Key]
        public int ProductGroupId { get; set; }

        [Required(ErrorMessage = "ProductGroupCode is required.")]
        public int ProductGroupCode { get; set; }

        [Required(ErrorMessage = "ProductGroupAcronym is required.")]
        public string ProductGroupAcronym { get; set; }

        [Required(ErrorMessage = "ProductGroupName is required.")]
        public string ProductGroupName { get; set; }

        //Accesso alla tabella padre
        public ICollection<ItemMaster> ItemMasters { get; set; }



    }
}
