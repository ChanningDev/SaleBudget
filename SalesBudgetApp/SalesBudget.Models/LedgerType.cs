using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    //Rappresenta l'omonima tabella nel db
    public class LedgerType
    {
        [Key]
        public int LedgerTypeId { get; set; }

        [Required(ErrorMessage = "LedgerTypeCode is required.")]
        public string LedgerTypeCode{ get; set; }

        [Required(ErrorMessage = "Scenario is required.")]
        public string Scenario { get; set; }

        [Required(ErrorMessage = "Statutory is required.")]
        public bool Statutory { get; set; }

        //Accesso alla tabella padre
        public ICollection<FBudget> FBudgets { get; set; }
    }
}
