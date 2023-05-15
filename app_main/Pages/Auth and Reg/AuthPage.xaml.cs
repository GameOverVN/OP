using app_main.classes;
using app_main.windows;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace app_main.Pages.Auth_and_Reg
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public MainWindow mainWindow;
        public AuthPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public string getLogin()
        {

            if (loginTextbox.Text != "")
            {
                TextBlockEmptyLogin.Visibility = Visibility.Hidden;
                return loginTextbox.Text;
            }
            else
            {
                TextBlockEmptyLogin.Visibility = Visibility.Visible;
            }
            return null;
        }

        private string getPassword()
        {
            if (passwordTextbox.Password != "")
            {
                TextBlockEmptyPassword.Visibility = Visibility.Hidden;
                return passwordTextbox.Password;
            }
            else
            {
                TextBlockEmptyPassword.Visibility = Visibility.Visible;
            }
            return null;
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            bool userExists = false;
            var users = MainWindow.getUsers();
            getPassword();
            foreach (var user in users)
            {
                if (getLogin() == user.Login && getPassword() == user.Password)
                {
                    userExists = true;
                }
            }

            if ((getLogin() == Arrays.getAdminLogin() && getPassword() == Arrays.getAdminPassword()))
            {

                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (userExists)
            {

                TextBlockNoUser.Visibility = Visibility.Hidden;
                mainWindow.OpenPage(MainWindow.pages.userWindow);
            }
            else
            {
                if (loginTextbox.Text != "" && passwordTextbox.Password != "")
                {
                    TextBlockNoUser.Visibility = Visibility.Visible;
                }
            }
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);

        }
    }
}
