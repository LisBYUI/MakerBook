using MakerBook.Models;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<ProfessionalModel> Professional { get; set; }
        public DbSet<ProfessionalAddressModel> ProfessionalAddress { get; set; }
        public DbSet<ProfessionalSocialMediaModel> ProfessionalSocialMedia { get; set; }
        public DbSet<ProfessionalProfileModel> ProfessionalProfile { get; set; }
        public DbSet<ServiceModel> Service { get; set; }
        public DbSet<ServiceAddressModel> ServiceAddress { get; set; }
        public DbSet<ServiceImageModel> ServiceImage { get; set; }

        public DbSet<UserModel> User { get; set; }
      
 
    }
}
