using app_main.Pages;
using OfficeOpenXml.Utils;
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

namespace app_main {
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Page {
        public MainWindow MainWindow { get; set; }
        public AdminWindow(MainWindow mainWindow) {
            MainWindow = mainWindow;
            InitializeComponent();
            
        }

        public void Button_UsersControl_Click(object sender, RoutedEventArgs e) {
            frame.Content = new UsersControl();
        }
        public void usersRefresh() {
            Button_UsersControl_Click(null,null);
        }
        public void Button_DataChange_Click(object sender, RoutedEventArgs e) {
           
            frame.Content = new DataChangePage();
        }
    }
}
