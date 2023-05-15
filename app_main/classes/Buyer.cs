using app_main.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_main.classes {
    public class Buyer {
        public Driver driver { get; set; }
        public string HomeAdress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Passport { get; set; }
        public int Price { get; set; }
        public string Email { get; set; }
        public string CarPassport { get; set; }
        public string Type { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public Buyer( string name, string surname, string middleName, string carpassport, string type, int price, DateTime dateStart, DateTime dateEnd, string email ) { 
            
            Name = CalculatePage.Driver.Name;
            Surname = CalculatePage.Driver.Surname;
            MiddleName = CalculatePage.Driver.MiddleName;
            CarPassport = carpassport;
            Type = type;
            Price = price;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Email = email;
        }
    }
}
