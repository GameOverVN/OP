using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_main {
    public class City {
        public string Name { get; set; }
        public double Ratio { get; set; }


        public City(string name, double ratio) { 
            Name = name;
            Ratio = ratio;
        }

    }
}
