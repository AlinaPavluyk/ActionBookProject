using System;
using System.Collections.Generic;

namespace ActionBook.Models
{
    public partial class ActionBooks
    {
        public ActionBooks()
        {
            ActionLists = new HashSet<ActionLists>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ActionLists> ActionLists { get; set; }
    }
}
