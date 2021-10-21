using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPOCO
{
    public class Developer
    {
        public string Name { get; set; }

        public int ID { get; set; }
        public bool PluralSight { get; set; }
        public Developer() { }
        public Developer(string name)
        {
            Name = name;
        }
        public Developer(string name, int id, bool pluralSight)
        {
            Name = name;
            ID = id;
            PluralSight = pluralSight;

        }

    }
}
