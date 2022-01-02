using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    public class UnToKg
    {
        [Key]
        public int UnToKgId { get; set; }

        [Required(ErrorMessage = "ConversionRate is required.")]
        public double ConversionRate { get; set; }


        //Accesso alla tabella padre
        public ICollection<ItemMaster> ItemMasters { get; set; }


    }
}
