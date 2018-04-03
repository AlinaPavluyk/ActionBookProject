using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ActionBook.Models
{
    public class ActionListContext : DbContext
    {
        public ActionListContext (DbContextOptions<ActionListContext> options)
            : base(options)
        {
        }

        public DbSet<ActionBook.Models.ActionLists> ActionLists { get; set; }
    }
}
