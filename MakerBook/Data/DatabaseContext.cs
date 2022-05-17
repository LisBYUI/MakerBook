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

        public DbSet<MakerBook.Models.UserModel>? User { get; set; }
    }
}
