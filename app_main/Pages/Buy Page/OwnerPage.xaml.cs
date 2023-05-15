using app_main.classes;
using System;
using System.Collections.Generic;
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

namespace app_main.Pages.Buy_Page {
    /// <summary>
    /// Логика взаимодействия для OwnerPage.xaml
    /// </summary>
    public partial class OwnerPage : Page {
        public DriverPage driverPage;

        private bool isOwner { get; set; }
         public Driver Driver { get; set; }
        public Buyer MyBuyer { get; set; }

        
        public OwnerPage(DriverPage driverPage) {
            InitializeComponent();
            this.driverPage = driverPage;
            Driver = CalculatePage.Driver;
            initInfoAboutOwner();
            driverPage.buyPage.getbackButton.Visibility = Visibility.Collapsed;

        }

        private void initInfoAboutOwner() {
            if (driverPage.checkBoxPolicyholder.IsChecked == true) {
                isOwner = true;
            }
            else {

                isOwner = false;
            }
            if (isOwner) {
                textBoxSurname.Text = Driver.Surname;
                textBoxName.Text = Driver.Name;
                textBoxMiddleName.Text = Driver.MiddleName;
                textBoxAge.Text = Driver.Age.ToString();
            }
            
        }

        public string getPassport() {
            var passort = textBoxPassport.Text;
            string[] counter = passort.Split(' ');
            if (counter.Length==2) {
                return passort;
            }
            return null;
        }

        public string getEmail() {
            var email = textBoxEmail.Text;
            string[] counter = email.Split('@');
            if (counter.Length==2) {
                if (email!="") {
                    return email;
                }
            }
            return null;
        }
        public string getAdress() {
            if (adressTextBox.Text!="") {
                return adressTextBox.Text;

            }
            return null;
        }


        private void Button_PreviousPage_Click(object sender, RoutedEventArgs e) {
           
            NavigationService navigation = NavigationService.GetNavigationService(this);
            navigation.GoBack();
           
        }

        private void Button_NextPage_Click(object sender, RoutedEventArgs e) {
            if(getPassport() == null && getEmail() == null && getAdress() == null)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Заполните все поля");
                messageBox.Show();
            }
            else
            {
                NavigationService.Navigate(new mainBuyPage(this));
            }
        }
        public Buyer createBuyer() {
            var driver = CalculatePage.Driver;
            string name = driver.Name;
            string surname = driver.Surname;
            string middlename = driver.MiddleName;
            string type;
            if (driverPage.buyPage.calculatePage.kaskoBtn.IsChecked == true) {
                type = driverPage.buyPage.calculatePage.kaskoBtn.Content.ToString();
            }
            else {
                type = driverPage.buyPage.calculatePage.osagoBtn.Content.ToString();
            }
            string email = getEmail();

            DateTime dateStart = DateTime.Now;
            DateTime dateEnd = DateTime.Now.AddYears(1);

            var buyer = new Buyer(name,surname,middlename, driverPage.getCarPassort(),type, CalculatePage.Price,dateStart  ,dateEnd ,email);
            return buyer;
        }
    }
}
