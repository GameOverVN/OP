using app_main.Pages.Buy_Page;
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

namespace app_main.Pages {
    /// <summary>
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page {
        public CalculatePage calculatePage;
        public static int Price { get; set; }
        public Car Car { get; set; }    
        public BuyPage(CalculatePage calculatePage) {
            InitializeComponent();
            openPage(buyPages.car);
            this.calculatePage = calculatePage;
            Car = calculatePage.getCar();
            Price = calculatePage.getTotalPrice();
        }
       
        public enum buyPages {
            car,
            driver,
            strahovatel,
            result
        }

        public void openPage(buyPages pages) {
            if (pages==buyPages.car) {
                frameBuyPage.Navigate(new carPage(this));
            }
        }
        
        private void Button_ToMainMenu_Click(object sender, RoutedEventArgs e) {
            NavigationService navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(calculatePage);
                        
        }
    }
}
