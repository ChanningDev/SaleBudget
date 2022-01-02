using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    //Rappresenta l'omonima tabella nel db
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CustomerName is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "CustomerGroupCode is required.")]
        public string CustomerGroupCode { get; set; }

        [Required(ErrorMessage = "CountryCode is required.")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "CustomerGroupName is required.")]
        public string CustomerGroupName { get; set; }

        [Required(ErrorMessage = "LicensingArea is required.")]
        public string LicensingArea { get; set; }

        //Collegamento alla tabella padre
        public ICollection<FBudget> FBudgets { get; set; }


    }
}
