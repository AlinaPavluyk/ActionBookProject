using ClassLibraryAB.Models;
using Microsoft.EntityFrameworkCore;


namespace ClassLibraryAB
{
    public class AB1 : DbContext
    {
        public AB1(DbContextOptions options) : base(options) { }
        public DbSet<Regestration> Regestrations { get; set; }
    }
}