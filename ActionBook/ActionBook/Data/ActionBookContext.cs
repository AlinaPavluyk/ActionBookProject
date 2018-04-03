using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ActionBook.Models
{
    public class ActionBookContext : DbContext
    {
        public ActionBookContext (DbContextOptions<ActionBookContext> options)
            : base(options)
        {
        }

        public DbSet<ActionBook.Models.ActionBooks> ActionBooks { get; set; }
    }
}
