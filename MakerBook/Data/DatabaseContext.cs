using MakerBook.Models;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<UserModel> User { get; set; }
      
    }
}
