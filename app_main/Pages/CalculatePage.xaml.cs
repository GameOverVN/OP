using app_main.windows;
using OfficeOpenXml;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace app_main.Pages {
    /// <summary>
    /// Логика взаимодействия для CalculatePage.xaml
    /// </summary>
    public partial class CalculatePage : Page {
        public static Car MyCar { get; set; }
        public static Driver Driver { get; set; }
        public static int Price { get; set; }
        public CalculatePage() {
            InitializeComponent();
            initComboBox();
            
        }
        public static string filePathGlobal = @"C:\Users\User\Desktop\practice\excelTables\";
        
        public List<Car> cars = getCars();
        private void Button_Calculate_Click(object sender, RoutedEventArgs e) {
            if (checkComboBoxCar() == true && checkDriverInfo() == true && checkDriverYear() == true &&  checkStaj() == true && checkDriverAmountOfAccidents() == true && checkCity() == true && checkAmountOfDrivers() == true && checkRegNumber() == true   ) {
            MyCar = getCar();
            Driver = getDriver();
            MainGrid.Visibility = Visibility.Hidden;
            totalPriceGrid.Visibility = Visibility.Visible;
            totalPriceTB.FontSize = 20;
                int kaskoPrice = Convert.ToInt32(MyCar.Price * 0.08);
                if (osagoBtn.IsChecked==true) {
                    Price = getTotalPrice();
                    totalPriceTB.Text = $"Сумма вашей страховки: {Price.ToString()} руб.";
                    
                }
                else {
                    Price = kaskoPrice;
                    totalPriceTB.Text = $"Сумма вашей страховки: {Price} руб.";
                }


            }
            


        }

        //TOTAL RESULT

        private void Button_CalculateTotalClose_Click(object sender, RoutedEventArgs e) {
            totalPriceGrid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;

        }

        public void Button_Buy_Click(object sender, RoutedEventArgs e) {
            totalPriceGrid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
            NavigationService navigation = NavigationService.GetNavigationService(this);
            var buyPage = new BuyPage(this);
            navigation.Navigate(buyPage);

        }

       

        private static List<Car> getCars() {

            FileInfo filePath = new FileInfo($"{filePathGlobal}Cars.xlsx");
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(filePath)) {
                var carsSheet = package.Workbook.Worksheets["Cars"];

                int row = carsSheet.Dimension.Rows - 1;
                var cars = new List<Car>();

                for (int i = 0; i < row; i++) {

                    Car car = new Car(null, null, 0, 0, 0);
                    int rowColumn = 2 + i;
                    car.Brand = carsSheet.Cells["B" + rowColumn].Value.ToString();
                    car.Model = carsSheet.Cells["C" + rowColumn].Value.ToString();
                    car.Power = Convert.ToDouble(carsSheet.Cells["D" + rowColumn].Value);
                    car.ReleaseYear = Convert.ToInt32(carsSheet.Cells["E" + rowColumn].Value.ToString());
                    car.Price = Convert.ToInt32(carsSheet.Cells["F" + rowColumn].Value.ToString());

                    cars.Add(car);

                }
                return cars;

            }
        }
        //INIT COMBOBOX
        public void initComboBox() {



            List<string> carBrands = new List<string>();
            foreach (var car in cars) {
                if (carBrands.Contains(car.Brand)) {
                    continue;
                }
                else {
                    carBrands.Add(car.Brand);

                }
            }
            carBrands.Sort();
            foreach (var brand in carBrands) {
                brandCombobox.Items.Add(brand);
            }
            brandCombobox.SelectionChanged += brandComboboxIndexChanged;
            initCityCombobox();
            setYearsToCombobox();
        }

        private void brandChangedAfterChoise() {
            brandCombobox.SelectionChanged += brandComboboxIndexChanged;
        }
        private void modelChangedAfterChoise() {
            modelCombobox.SelectionChanged += modelComboboxIndexChanged;
        }
        private void powerChangedAfterChoise() {
            powerCombobox.SelectionChanged += powerComboboxIndexChanged;
        }

        private void brandComboboxIndexChanged(object sender, SelectionChangedEventArgs e) {
            List<string> carModels = new List<string>();

            modelCombobox.Items.Clear();
            string selectedBrand = brandCombobox.SelectedItem.ToString();
            foreach (var car in cars) {
                if (car.Brand == selectedBrand) {
                    carModels.Add(car.Model);
                }
                else {
                    continue;
                }
            }
            carModels.Sort();
            foreach (var model in carModels) {
                modelCombobox.Items.Add(model);
            }
            modelCombobox.SelectionChanged += modelComboboxIndexChanged;

        }
        private void modelComboboxIndexChanged(object sender, SelectionChangedEventArgs e) {
            powerCombobox.Items.Clear();
            if (modelCombobox.SelectedItem == null) {
                brandChangedAfterChoise();
            }
            else {

                string selectedModel = modelCombobox.SelectedItem.ToString();
                foreach (var car in cars) {
                    if (car.Model == selectedModel && car.Brand ==brandCombobox.SelectedItem.ToString()) {
                        powerCombobox.Items.Add(car.Power);
                    }
                    else {
                        continue;
                    }
                }
            }
            powerCombobox.SelectionChanged += powerComboboxIndexChanged;
        }
        private void powerComboboxIndexChanged(object sender, SelectionChangedEventArgs e) {
            if (modelCombobox.SelectedItem == null) {
                brandChangedAfterChoise();
                releaseYearCombobox.Items.Clear();
            }
            if (powerCombobox.SelectedItem == null) {
                modelChangedAfterChoise();
                releaseYearCombobox.Items.Clear();
            }
            else {
                releaseYearCombobox.Items.Clear();
                string selectedPower = powerCombobox.SelectedItem.ToString();
                foreach (var car in cars) {
                    if (car.Power.ToString() == selectedPower) {
                        releaseYearCombobox.Items.Add(car.ReleaseYear);
                    }
                    else {
                        continue;
                    }
                }
            }

        }

        //GET CAR FROM COMBOBOX//
        public Car getCar() {
            cars = getCars();
            checkComboBoxCar();

            try {
                foreach (var car in cars) {
                    if (brandCombobox.Text == car.Brand && modelCombobox.Text == car.Model && powerCombobox.Text == car.Power.ToString() && releaseYearCombobox.Text == car.ReleaseYear.ToString()) {
                        car.RegNumber = regnumTextBox.Text;
                        return car;

                    }


                }
            }
            catch (Exception) {

                throw;
            }

           
            return null;


        }

        //DRIVER//

        public Driver getDriver() {
            cars = getCars();
            checkDriver();
            
            try {
                var driver = new Driver(nameTextBox.Text, surnameTextBox.Text, middlenameTextBox.Text, Convert.ToInt32(ageComboBox.SelectedItem), Convert.ToInt32(experienceTextBox.Text), Convert.ToInt32(amountOfAccidentsTextBox.Text),
               getCar());
                return driver;
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            return null;
           
        }

        //CITY//
        private bool checkCity() {
            if (cityCombobox.Text.Length==0) {
                TextBlockNoDriverInfo.Visibility = Visibility.Visible;
                return false;
            }
            return true;

        }
        private void initCityCombobox() {
            List<string> listOfCities = new List<string>();
            foreach (var city in Arrays.cities) {
                if (listOfCities.Contains(city.Name)) {
                    continue;
                }
                else {
                    listOfCities.Add(city.Name);

                }
            }
            listOfCities.Sort();
            foreach (var city in listOfCities) {
                cityCombobox.Items.Add(city);
            }
        }

        private City getCity() {
            checkCity();
            foreach (var city in Arrays.cities) {
                if (cityCombobox.Text == city.Name)

                    return city;
            }
            return null;

        }



        //ГОД, СТАЖ И КОЛИЧЕСТВО ДТП
        private void setYearsToCombobox() {
            const int eighteen = 18;
            const int maxBorder = 1950;
            int nowYear = DateTime.Now.Year;
            int[] years = new int[nowYear - eighteen - maxBorder + 1];
            for (int i = 0; i < years.Length; i++) {
                years[i] = maxBorder + i;
            }
            ageComboBox.ItemsSource = years;




        }


        //САМ КАЛЬКУЛЯТОР 

        public int getTotalPrice() {
            int totalPrice = 0;
            totalPrice = (int)(3500 * getTerritoryCoef() * getKMB() * getAgeCoef() * getPowerCoef() * getAmountOfDriversCoef());
            return totalPrice;
        }


        private double getTerritoryCoef() {
            City myCity = getCity();
            double territoryKoef = myCity.Ratio;
            return territoryKoef;
        }

        //можно сделать уровневую систему. функция для получения уровня и функция для получения коэф-та. Получаю уровень, затем отправляю его в другой свитч и смотрю по авариям
        private double getKMB() {
            int amountOfAccidents = Convert.ToInt32(amountOfAccidentsTextBox.Text);
            double kmb = 1.17;
            switch (amountOfAccidents) {
                case 0:
                    kmb = 1;
                    break;
                case 1:
                    kmb = 2.25;
                    break;
                case 2:
                    kmb = 3.92;
                    break;
                case 3:
                    kmb = 3.92;
                    break;
                default:
                    kmb = 3.92;
                    break;
            }

            return kmb;
        }
        private double getAgeCoef() {
            double ageCoef = 0;
            int experience = Convert.ToInt32(experienceTextBox.Text);
            int age = DateTime.Now.Year - Convert.ToInt32(ageComboBox.Text);
            switch (age) {
                case 18:
                case 19:
                case 20:
                case 21:
                    switch (experience) {
                        case 0: ageCoef = 1.93; break;
                        case 1: ageCoef = 1.9; break;
                        case 2: ageCoef = 1.87; break;
                        case 3: case 4: ageCoef = 1.66; break;
                        default: ageCoef = 1.64; break;
                    }
                    break;
                case 22:
                case 23:
                case 24:
                    switch (experience) {
                        case 0: ageCoef = 1.79; break;
                        case 1: ageCoef = 1.77; break;
                        case 2: ageCoef = 1.76; break;
                        case 3: case 4: ageCoef = 1.08; break;
                        case 5: case 6: ageCoef = 1.06; break;
                        case 7: case 8: case 9: ageCoef = 1.06; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 1.06; break;
                        default: ageCoef = 1.64; break;
                    }
                    break;
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    switch (experience) {
                        case 0: ageCoef = 1.77; break;
                        case 1: ageCoef = 1.68; break;
                        case 2: ageCoef = 1.61; break;
                        case 3: case 4: ageCoef = 1.06; break;
                        case 5: case 6: ageCoef = 1.05; break;
                        case 7: case 8: case 9: ageCoef = 1.05; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 1.01; break;
                        default: ageCoef = 1.64; break;
                    }
                    break;
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                    switch (experience) {
                        case 0: ageCoef = 1.62; break;
                        case 1: ageCoef = 1.61; break;
                        case 2: ageCoef = 1.59; break;
                        case 3: case 4: ageCoef = 1.04; break;
                        case 5: case 6: ageCoef = 1.04; break;
                        case 7: case 8: case 9: ageCoef = 1.01; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 0.96; break;
                        default: ageCoef = 0.95; break;
                    }
                    break;
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                    switch (experience) {
                        case 0: ageCoef = 1.61; break;
                        case 1: ageCoef = 1.59; break;
                        case 2: ageCoef = 1.58; break;
                        case 3: case 4: ageCoef = 0.99; break;
                        case 5: case 6: ageCoef = 0.96; break;
                        case 7: case 8: case 9: ageCoef = 0.95; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 0.95; break;
                        default: ageCoef = 0.94; break;
                    }
                    break;
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                    switch (experience) {
                        case 0: ageCoef = 1.59; break;
                        case 1: ageCoef = 1.58; break;
                        case 2: ageCoef = 1.57; break;
                        case 3: case 4: ageCoef = 0.95; break;
                        case 5: case 6: ageCoef = 0.95; break;
                        case 7: case 8: case 9: ageCoef = 0.94; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 0.94; break;
                        default: ageCoef = 0.94; break;
                    }
                    break;
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                    switch (experience) {
                        case 0: ageCoef = 1.58; break;
                        case 1: ageCoef = 1.57; break;
                        case 2: ageCoef = 1.56; break;
                        case 3: case 4: ageCoef = 0.96; break;
                        case 5: case 6: ageCoef = 0.96; break;
                        case 7: case 8: case 9: ageCoef = 0.94; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 0.94; break;
                        default: ageCoef = 0.93; break;
                    }
                    break;
                default:
                    switch (experience) {
                        case 0: ageCoef = 1.55; break;
                        case 1: ageCoef = 1.54; break;
                        case 2: ageCoef = 1.53; break;
                        case 3: case 4: ageCoef = 0.92; break;
                        case 5: case 6: ageCoef = 0.91; break;
                        case 7: case 8: case 9: ageCoef = 0.91; break;
                        case 10: case 11: case 12: case 13: case 14: ageCoef = 0.91; break;
                        default: ageCoef = 0.90; break;
                    }
                    break;
            }
            return ageCoef;
        }
        private double getPowerCoef() {
            double powerCoef = 0;
            double power = getCar().Power;
            if (power <= 50) powerCoef = 0.6;
            else if (power > 50 && power <= 70) powerCoef = 1.0;
            else if (power > 70 && power <= 100) powerCoef = 1.1;
            else if (power > 100 && power <= 120) powerCoef = 1.2;
            else if (power > 120 && power <= 150) powerCoef = 1.4;
            else { powerCoef = 1.6; }

            return powerCoef;
        }
        private double getAmountOfDriversCoef() {
            int amountOfDrivers = Convert.ToInt32(driversTextBox.Text);
            double amountCoef = 0;
            if (amountOfDrivers == 1) amountCoef = 1;
            else { amountCoef = 2.32; }
            return amountCoef;

        }

        //ОБРАБОТКА ОШИБОК 

        private bool checkComboBoxCar() {
            
            if (brandCombobox.Text.Length==0) {
                TextBlockNoMark.Visibility = Visibility.Visible;
                return false;

            }
            else
            {
                TextBlockNoMark.Visibility = Visibility.Hidden;
            }

            if (modelCombobox.Text.Length==0) {
                TextBlockNoModel.Visibility = Visibility.Visible;
                return false;

            }
            else
            {
                TextBlockNoModel.Visibility = Visibility.Hidden;
            }

            if (powerCombobox.Text.Length==0) {
                TextBlockNoPower.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                TextBlockNoPower.Visibility = Visibility.Hidden;
            }

            if (releaseYearCombobox.Text.Length == 0) {
                TextBlockNoYear.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                TextBlockNoYear.Visibility = Visibility.Hidden;
            }
            return true;
        }
        private void checkDriver() {
            checkDriverInfo();
            checkStaj();
            checkRegNumber();
            checkDriverYear();
            checkDriverAmountOfAccidents();
            checkAmountOfDrivers();
        }
        private bool checkEmptySurname() {
            if (surnameTextBox.Text.Length == 0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();
                return false;
            }
            return true;
        }
        private bool checkEmptyName() {
            if (nameTextBox.Text.Length == 0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();
                return false;
            }
            return true;
        }
        private bool checkEmptyMiddleName() {
            if (middlenameTextBox.Text.Length == 0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();
                return false;
            }

            return true;
        }
        private bool checkDriverInfo() {
            bool OK=false;
                OK = checkEmptySurname();
                OK = checkEmptyName();
                OK = checkEmptyMiddleName();
           
            return OK;
            
        
        }
        private bool checkDriverYear() {
            if (ageComboBox.Text.Length==0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();
                return false;
            }
            return true;
        }
        private bool checkDriverAmountOfAccidents() {
            if (amountOfAccidentsTextBox.Text.Length==0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();

                return false;
            }
            return true;
        }
        private bool checkAmountOfDrivers() {
            if (driversTextBox.Text.Length==0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();
                return false;
            }
            else {
                int amount = Convert.ToInt32(driversTextBox.Text);
                if (amount == 0) {
                    CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                    messageBox.Show();
                    return false;
                }

                return true ;
            }
            
        }
        private bool checkStaj() {
            if (experienceTextBox.Text.Length==0) {
                CustomMessageBox messageBox = new CustomMessageBox("Введите полную информацию о водителе");
                messageBox.Show();
                return false;
            }
            else {

            int experience = DateTime.Now.Year- Convert.ToInt32(ageComboBox.SelectedItem)-18;
            if (!(Convert.ToInt32(experienceTextBox.Text)<experience)) {
                    CustomMessageBox messageBox = new CustomMessageBox($"Максимально допустимый стаж - {experience - 1}");
                    messageBox.Show();
                   /* MessageBox.Show($"Максимально допустимый стаж - {experience-1}");*/
                return false;
            }
            }
            return true;
        }
        private bool checkRegNumber() {
            
            var number = regnumTextBox.Text.ToCharArray();
            if (number.Length<8 || number.Length>9) {
                TextBlockNoCarNumber.Visibility = Visibility.Visible;
                return false;
            }
            else {
                if (number.Length==8 && !((Char.IsLetter(number[0])) && (Char.IsDigit(number[1])) && (Char.IsDigit(number[2])) && (Char.IsDigit(number[3])) && (Char.IsLetter(number[4])) && (Char.IsLetter(number[5])) && (Char.IsDigit(number[6])) && (Char.IsDigit(number[7])))) {
                    TextBlockNoCarNumber.Visibility = Visibility.Visible;
                    return false;
                }
                 
                else if (number.Length==9 && !((Char.IsLetter(number[0])) && (Char.IsDigit(number[1])) && (Char.IsDigit(number[2])) && (Char.IsDigit(number[3])) && (Char.IsLetter(number[4])) && (Char.IsLetter(number[5])) && (Char.IsDigit(number[6])) && (Char.IsDigit(number[7])) && (Char.IsDigit(number[8])))) {
                    TextBlockNoCarNumber.Visibility = Visibility.Visible;
                    return false;
                }
            }
            return true;
        }
       



        //Запрет ввода
        private void experienceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text,0)) {
                e.Handled = true;
            }
        }

        private void surnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (Char.IsDigit(e.Text, 0)) {
                e.Handled = true;
            }
        }

        private void nameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (Char.IsDigit(e.Text, 0)) {
                e.Handled = true;
            }
        }

        private void middlenameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (Char.IsDigit(e.Text, 0)) {
                e.Handled = true;
            }
        }

        private void amountOfAccidentsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) {
                e.Handled = true;
            }
        }

        private void driversTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) {
                e.Handled = true;
            }
        }

        private void regnumTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = "0123456789АБВГДЕЖЗИЙКЛМОПРСТУФХЦЧШЩЫЭЮЯ".IndexOf(e.Text)<0;
                
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {

        }
    }
}
