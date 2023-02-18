using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMezzanine
{
    public class MezzanineItem
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }

        public MezzanineItem(string name, string location, int quantity)
        {
            Name = name;
            Location = location;
            Quantity = quantity;
        }
    }
}
