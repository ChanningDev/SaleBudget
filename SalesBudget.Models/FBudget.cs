using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalesBudget.Models
{
    //Rappresenta l'omonima tabella nel db
    public class FBudget
    {
        [Key]
        public int BudgetId { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "FoC is required.")]
        public string FreeOfCharge { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Display(Name = "Unit Price")]
        public float UnitPrice { get; set; }


        //12 campi, uno per ogni mese dell'anno.
        //Opzionali perchè non è obbligatorio suddividere il budget su 12 mensilità.
        //L'importo di tutti i mesi sommati non deve superare il TotalAmount.
        public int Jan { get; set; }
        public int Feb { get; set; }
        public int Mar { get; set; }
        public int Apr { get; set; }
        public int May { get; set; }
        public int Jun { get; set; }
        public int Jul { get; set; }
        public int Ago { get; set; }
        public int Sept { get; set; }
        public int Oct { get; set; }
        public int Nov { get; set; }
        public int Dec { get; set; }

        
        private int Total;
        public int TotalMonths 
        {
            get
            {
                return Jan + Feb + Mar + Apr + May
                    + Jun + Jul + Ago + Sept + Oct + Nov + Dec;
            }
            set
            {
                Total = Jan + Feb + Mar + Apr + May
                    + Jun + Jul + Ago + Sept + Oct + Nov + Dec;
            }
        }




        [Display(Name = "Month Nr")]
        [Required(ErrorMessage = "Month Nr is required.")]
        [Range(1, 12, ErrorMessage = "The value must be between 1 and 12!")]
        public string MonthNr { get; set; }


        [Display(Name = "Unit of Measure")]
        [Required(ErrorMessage = "Unit of Measure is required.")]
        public string UnitOfMeasure { get; set; }


        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity in untis is required.")]
        public int Quantity { get; set; }


        private float Result;
        public float TotalAmount
        {
            get
            {
                return UnitPrice * Quantity;
            }
            set
            {
                Result = UnitPrice * Quantity;
            }
        }

        //Da definire automaticamente in base all'ultimo utente che ha utilizzato 'app
        public string LastUser 
        {
            get; set;
        }

        //Da definire automaticamente in base all'ultimo software che ha utilizzato 'app
        public int ProgramId 
        {
            get; set; 
        }

        //Campo autocalcolato che salva l'ultimo accesso all'app
        public DateTime LastUpdate { get; set; } = DateTime.Now;


        //Chiavi esterne
        //Accesso a ItemMaster
        [Display(Name = "Item")]
        public int ItemMasterId { get; set; }
        public ItemMaster ItemMaster { get; set; }


        //Accesso a Company
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }


        //Accesso a LedgerType
        [Display(Name = "Scenario")]
        public int LedgerTypeId { get; set; }
        public LedgerType LedgerType { get; set; }


        //Accesso a Customer
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}
