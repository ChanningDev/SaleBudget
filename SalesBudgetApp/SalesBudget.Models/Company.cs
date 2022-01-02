using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    //Rappresenta l'omonima tabella nel db
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "CompanyName is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Acronym is required.")]
        public string Acronym { get; set; }

        [Required(ErrorMessage = "CurrencyBase is required.")]
        public string CurrencyBase { get; set; }

        [Required(ErrorMessage = "CurrencyGroup is required.")]
        public string CurrenyGroup { get; set; }

        [Required(ErrorMessage = "Operative is required.")]
        public bool Operative { get; set; }

        //Collegamento alla tabella padre
        public ICollection<FBudget> FBudgets { get; set; }
    }
}
