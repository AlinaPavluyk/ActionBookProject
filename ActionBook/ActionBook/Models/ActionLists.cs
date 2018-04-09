using System;
using System.Collections.Generic;

namespace ActionBook.Models
{
    public partial class ActionLists
    {
        public ActionLists()
        {
            InverseChoise1Navigation = new HashSet<ActionLists>();
            InverseChoise2Navigation = new HashSet<ActionLists>();
            InverseChoise3Navigation = new HashSet<ActionLists>();
            InverseChoise4Navigation = new HashSet<ActionLists>();
        }

        public int Id { get; set; }
        public int ActionBookId { get; set; }
        public string Name { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public byte[] Image4 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public int? Choise1 { get; set; }
        public int? Choise2 { get; set; }
        public int? Choise3 { get; set; }
        public int? Choise4 { get; set; }
        public int? ListType { get; set; }

        public ActionBooks ActionBook { get; set; }
        public ActionLists Choise1Navigation { get; set; }
        public ActionLists Choise2Navigation { get; set; }
        public ActionLists Choise3Navigation { get; set; }
        public ActionLists Choise4Navigation { get; set; }
        public ICollection<ActionLists> InverseChoise1Navigation { get; set; }
        public ICollection<ActionLists> InverseChoise2Navigation { get; set; }
        public ICollection<ActionLists> InverseChoise3Navigation { get; set; }
        public ICollection<ActionLists> InverseChoise4Navigation { get; set; }
    }
}
