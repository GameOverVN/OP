using app_main.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_main {
    public static class Arrays {

        private static string adminLogin = "admin";
        private static string adminPassword = "admin123";
        public static string getAdminLogin() {
            return adminLogin;
        }
        public static string getAdminPassword() {
            return adminPassword;
        }


        
        //public static ObservableCollection<Car> cars = new ObservableCollection<Car>() {
        //    new Car("BMW","x5 30d IV", 265,2018, 7_500_000),
        //    new Car("BMW","x5 M50i IV", 340,2019, 7_850_000),
        //    new Car("Audi", "f3 III", 150, 2018, 1_690_000),
        //    new Car("BMW","5-Series 520d", 190,2020, 3_500_000),
        //    new Car("Audi", "q8", 240, 2019, 7_090_000),
        //    new Car("BMW", "5-Series M550i", 530,2020, 7_150_000)
            
        //};
        public static ObservableCollection<City> cities = new ObservableCollection<City>() {
            new City("Калуга", 1.16),
            new City("Москва", 1.8),
            new City("Санкт-Петербург", 1.64),
            new City("Смоленск", 1.16),
            new City("Брянск", 1.4),
            new City("Белгород", 1.24),
            new City("Обнинск", 1.24),
            new City("Калининград", 1.08),
        };
    }
}
