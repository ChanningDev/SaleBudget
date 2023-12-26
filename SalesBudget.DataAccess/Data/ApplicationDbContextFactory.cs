using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SalesBudget.DataAccess.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        // Replace with your actual connection string
        optionsBuilder.UseSqlServer("Data Source = server85.hostfactory.ch,1435 ; Initial Catalog = admin_salesbudget ; User Id = channing ; Password = fT4K#io64dFf%rpl");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
