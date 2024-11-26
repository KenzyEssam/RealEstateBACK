using Microsoft.EntityFrameworkCore;

namespace RealEstate.Models
{
    public class RealEstateContext : DbContext

    {
        public DbSet<Delegate> Delegates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingPermission> BookingPermissions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<InvestmentUnit> InvestmentUnits { get; set; }
        public DbSet<RentalUnit> RentalUnits { get; set; }
        public DbSet<Category> Categorys { get; set; }


        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        { 
        
        
        }

        
    }
}
