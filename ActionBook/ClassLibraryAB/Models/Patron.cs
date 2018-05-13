using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryAB.Models
{
    public class Regestration
    {
     
        public string Name { get; set; }
        public virtual Card Card { get; set }
    }
}
