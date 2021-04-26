using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalWorkLinq2
{  
    /*корабль – название, число пассажиров, пароходство, год постройки, тип(речной, морской), шифр реки/моря.*/
    class Ship
    {
        public string Name { get; set; }

        public int NumbOfPassenger { get; set; }

        public string ShippingCompany { get; set; }

        public string YearOfConstruction { get; set; }

        public string Type { get; set; }

        public string Ciper { get; set; }

    }
}
