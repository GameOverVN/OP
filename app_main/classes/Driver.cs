using app_main.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace app_main {
    public class Driver {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public int AmountOfAccidents { get; set; }

        private Car DriverCar { get; }

        public Driver() {

        }
        public Driver(string name, string surname, string middlename, int age, int experience, int amountOfAccidents, Car driverCar ) { 
            Name = name;
            Surname = surname; 
            MiddleName = middlename;
            Age = age;
            Experience = experience;
            AmountOfAccidents = amountOfAccidents;
            DriverCar = driverCar;
        }

        public void ShowInfo() {
            MessageBox.Show($"Name: {Name}, Surname: {Surname}, MiddleName: {MiddleName}, Age: {Age}, Experience: {Experience}, Name: {AmountOfAccidents}, Car: {DriverCar}, ");
        }

    }
}
