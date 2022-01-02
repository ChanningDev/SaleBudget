using Microsoft.EntityFrameworkCore;
using SalesBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Istanziam un DbSet<> per ogni modello
        public DbSet<FBudget> Budget { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<LedgerType> LedgerType { get; set; }
        public DbSet<PharmaForm> PharmaForm { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<UnToBulk> UnToBulk { get; set; }
        public DbSet<UnToKg> UnToKg { get; set; }

    }
}
