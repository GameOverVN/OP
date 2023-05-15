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
    /// Логика взаимодействия для carPage.xaml
    /// </summary>
    public partial class carPage : Page {
        public BuyPage buyPage;
        public Car Car { get; set; }
        public carPage(BuyPage buyPage) {

            InitializeComponent();
            buyPage.getbackButton.Visibility = Visibility.Visible;
            this.buyPage = buyPage;
            Car = CalculatePage.MyCar;
            initInfo();
        }
        private void initInfo() {
            textBoxBrand.Text = Car.Brand;
            textBoxModel.Text = Car.Model;
            textBoxPower.Text = Convert.ToString(Car.Power);
            textBoxRelease.Text = Convert.ToString(Car.ReleaseYear);
            textBoxRegNumber.Text = Car.RegNumber;

        }

        private void Button_NextDriverPage_Click(object sender, RoutedEventArgs e) {
            buyPage.frameBuyPage.Navigate(new DriverPage(buyPage)); 
        }
    }
}
