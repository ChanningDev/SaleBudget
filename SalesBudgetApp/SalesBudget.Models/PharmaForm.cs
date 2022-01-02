using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    public class PharmaForm
    {

        [Key]
        public int PharmaFormId { get; set; }

        [Required(ErrorMessage = "PharmaFormAcronym is required.")]
        public string PharmaFormAcronym { get; set; }

        [Required(ErrorMessage = "PharmaFormName is required.")]
        public string PharmaFormName { get; set; }


        //Accesso alla tabella padre
        public ICollection<ItemMaster> ItemMasters { get; set; }

    }
}
