using app_main.classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace app_main.windows
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Page
    {
        public MainWindow mainWindow;
        public RegWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        public static List<int> idList = new List<int>();

        public static List<int> IDList
        {
            get { return idList; }
        }
        public static void toExcel(List<User> users)
        {
            var excelApp = new ExcelPackage();
        }
        public ObservableCollection<User> users = MainWindow.getUsers();

        public string getRegLogin()
        {
            string regLogin = loginRegTextbox.Text;
            if (regLogin != "")
            {
                return regLogin;
            }
            return null;
        }
        public string getRegPassword()
        {
            string regPassword = passwordRegTextbox.Password;
            if (regPassword != "")
            {
                return regPassword;
            }
            return null;

        }
        private int getRandomID()
        {
            int randomID = 0;
            Random rnd = new Random();
            foreach (var user in users)
            {
                idList.Add(user.ID);
            }
            do
            {
                randomID = rnd.Next(1, 1000);
            } while (idList.Contains(randomID));

            return randomID;
        }
        private void Button_CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            ExcelLoader excelLoader = new ExcelLoader();
            var logins = new List<string>();

            foreach (var user in users)
            {
                logins.Add(user.Login);
            }

            if (logins.Contains(getRegLogin()))
            {
                TextBlockPasswordNotEqual.Visibility = Visibility.Hidden;
                TextBlockUserAlreadyExist.Visibility = Visibility.Visible;
            }
            else
            {

                bool emptyLogin;
                if (getRegLogin() == null)
                {
                    emptyLogin = true;
                }
                else
                {
                    emptyLogin = false;
                }

                bool emptyPassword;
                if (getRegPassword() == null)
                {
                    emptyPassword = true;
                }
                else
                {
                    emptyPassword = false;
                }

                if (emptyLogin)
                {
                    TextBlockUserAlreadyExist.Visibility = Visibility.Hidden;
                    TextBlockPasswordNotEqual.Visibility = Visibility.Hidden;
                    TextBlockEmptyLogin.Visibility = Visibility.Visible;

                }
                else
                {
                    TextBlockEmptyLogin.Visibility = Visibility.Hidden;
                }

                if (emptyPassword)
                {
                    TextBlockUserAlreadyExist.Visibility = Visibility.Hidden;
                    TextBlockPasswordNotEqual.Visibility = Visibility.Hidden;
                    TextBlockEmptyPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockEmptyPassword.Visibility = Visibility.Hidden;
                }

                if (password2RegTextbox.Password == "")
                {
                    TextBlockUserAlreadyExist.Visibility = Visibility.Hidden;
                    TextBlockPasswordNotEqual.Visibility = Visibility.Hidden;

                    TextBlockEmptyPassword2.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockEmptyPassword2.Visibility = Visibility.Hidden;
                }

                if ((!emptyLogin && !emptyPassword) && (password2RegTextbox.Password != getRegPassword()))
                {
                    TextBlockUserAlreadyExist.Visibility = Visibility.Hidden;
                    TextBlockPasswordNotEqual.Visibility = Visibility.Visible;
                }
                else if (!emptyLogin && !emptyPassword)
                {
                    TextBlockUserAlreadyExist.Visibility = Visibility.Hidden;
                    TextBlockPasswordNotEqual.Visibility = Visibility.Hidden;
                    Random rnd = new Random();
                    User newUser = new User(getRandomID(), getRegLogin(), getRegPassword());
                    excelLoader.SetUserToExcel(newUser);
                    CustomMessageBox messageBox = new CustomMessageBox("Пользователь создан");
                    messageBox.Show();
                    mainWindow.OpenPage(MainWindow.pages.login);

                }
            }
        }


        private void deleteIfExists(FileInfo file)
        {
            if (file.Exists) { file.Delete(); }
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }
    }
}
