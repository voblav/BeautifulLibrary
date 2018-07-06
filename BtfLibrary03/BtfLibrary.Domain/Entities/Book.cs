using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtfLibrary.Domain.Entities
{
    public class Book
    {
        public int IdBook { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

    }
}
