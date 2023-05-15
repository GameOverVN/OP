using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace app_main {
    public class Car {
        private string brand;
        public string Brand {
            get { return brand; }
            set { brand = value; }
        }
        private string model;
        public string Model {
            get { return model; }
            set { model = value; }
        }
        private double power;
        public double Power {
            get { return power; }
            set { power = value; }
        }
        private int releaseYear;
        public int ReleaseYear {
            get { return releaseYear; }
            set { releaseYear = value; }
        }

        private int price;
        public int Price {
            get { return price; }
            set { price = value; }
        }

        private string regNumber;
        public string RegNumber {
            get { return regNumber; }
            set { regNumber = value; }
        }

        public void printInfo() {
            MessageBox.Show($"Brand: {brand}, Model: {model}, Power: {power}, release: {releaseYear}, Price: {price}, RegNumber: {regNumber}");
        }

        public Car(string brand, string model, float power, int releaseYear, int price) {
            this.brand = brand;
            this.model = model;
            this.power = power;
            this.releaseYear = releaseYear;
            this.price = price;
        }
        
    }
}
