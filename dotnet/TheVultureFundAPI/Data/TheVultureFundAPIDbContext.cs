using TheVultureFundAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TheVultureFundAPI.Data
{
    public class TheVultureFunAPIDbContext : DbContext
    {
        public TheVultureFunAPIDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Contact> Contacts { get; set; }
    }
}