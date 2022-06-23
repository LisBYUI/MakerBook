using MakerBook.Models;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<OrderDetailModel> OrderDetail { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<ProfessionalModel> Professional { get; set; }
        public DbSet<ProfessionalSocialMediaModel> ProfessionalSocialMedia { get; set; }
        public DbSet<ProfessionalProfileModel> ProfessionalProfile { get; set; }
        public DbSet<ServiceImageModel> ServiceImage { get; set; }
        public DbSet<ServiceModel> Service { get; set; }


        public DbSet<UserModel> User { get; set; }
      
 
    }
}
