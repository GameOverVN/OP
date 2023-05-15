using app_main.windows;
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
using System.Windows.Shapes;
using app_main.classes;
using OfficeOpenXml;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using app_main.Pages.Auth_and_Reg;

namespace app_main
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string filePathGlobal = ExcelLoader.filePathSenin;

        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
        }
        public enum pages
        {
            login, regin, userWindow
        }


        public static ObservableCollection<User> getUsers()
        {
            FileInfo filePath = new FileInfo($"{filePathGlobal}Users.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(filePath))
            {
                var usersList = package.Workbook.Worksheets["Users"];

                int row = usersList.Dimension.Rows - 1;
                var users = new ObservableCollection<User>();

                for (int i = 0; i < row; i++)
                {

                    User user = new User(0, null, null);
                    int rowColumn = 2 + i;
                    user.ID = Convert.ToInt32(usersList.Cells["A" + rowColumn].Value);
                    user.Login = usersList.Cells["B" + rowColumn].Value.ToString();
                    user.Password = usersList.Cells["C" + rowColumn].Value.ToString();
                    users.Add(user);

                }
                return users;

            }
        }
        public void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
                frameMainWindow.Navigate(new AuthPage(this));
            }
            else if (pages == pages.regin)
            {
                frameMainWindow.Navigate(new RegWindow(this));
            }
            else if (pages == pages.userWindow) {
                frameMainWindow.Navigate(new UserWindow(this));
            }
        }

    }
}
