using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Books> Books { get; set; }
    }
}
